using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class movecontrols : MonoBehaviour
{
    float speed = 20.0f;
    public int lives = 13;

    //DECLARING GUI COMPONENTS/OBJECTS THAT ARE ASSIGNED IN THE UNITY EDITOR:
    public Text livess;
    public Text Score;

    public Text GameTime;
    public GameObject Gtime;

    //GAME VALUES:
    public float score = 0f;
    public float latestscore = 0f;

    float timer = 0.2f;
    public float gameTime = 15.0f;

    public GameObject Shooter; //SHOOTER OBJECT DECLARED, ASSIGNED IN EDITOR, MULTIPLE INSTANCES OF THIS CAN BE CONSTRUCTED (AND WILL) IN FUNCTION: void createShooter() IN LINE 70
    public GameObject KO; //GUI COMPONENT, DISPLAYS 'GAME OVER MESSAGE', THEREFORE NAMED 'KO'
    public GameObject DontDestroy; //THE CANVAS OR GUI COMPONENT, THEREFORE NAMED "DontDestroy" AS OTHERWISE GUI COMPONENTS WILL NOT SHOW

  
    Scene currentScene;

    private int buildIndex; //CONTAINS THE INDEX NUMBER OF THE SCENE: 'currentScene' ASSIGNED IN LINES 49 AND 50

    ScoreStack scoreScript3 = null;

    void Start() {
        GameObject GO5 = GameObject.FindWithTag("ScoreStack"); //GETS OBJECT CONTAINING ScoreStack CLASS

        try {
            scoreScript3 = GO5.GetComponent<ScoreStack>(); //GETS ScoreStack CLASS IN ORDER TO MUTATE SCORE STACK
        }

        catch (NullReferenceException e) {
            UnityEngine.Debug.Log("ScoreStack Object not Accessed:  " + e);
        }

        currentScene = SceneManager.GetActiveScene();
        buildIndex = currentScene.buildIndex;

        UnityEngine.Debug.Log("Current Build Index/Scene Number: " + buildIndex);
        
        Score.text = "Score: " + (int)score; //SETS VALUE OF GUI TEXT OBJECTS
        livess.text = "" + lives;
        GameTime.text = "Time Left: " + (int)gameTime + " s";
    }

    public bool gameOver() { //CHECKS IF CONDITIONS FOR GAME OVER ARE MET
        if(lives < 0 || gameTime <= 0.0f) {
            return true;
        }
        else {
            return false;
        }
    }

    public void createShooter() {
        GameObject instantiatedBullet = Instantiate(Shooter, transform.position, transform.rotation) as GameObject; //CONSTRUCTOR FOR SHOOTER OBJECT WITH POSITON AND ROTATION VECTOR
    }

    void Update()
    {
        if(!gameOver()) {
            gameTime -= Time.deltaTime; //CONTINUOUSLY SUBRACTS FROM GAME TIME TO SHOW HOW MUCH TIME IS LEFT
            GameTime.text = "Time Left: " + (int)gameTime + " s";

            try { 
                KO.SetActive(false); //MAKING APPROPRIATE GUI COMPONENTS VISIBLE OR NOT
                Gtime.SetActive(true);
            }

            catch {
                UnityEngine.Debug.Log("KO and GTime Null");
            }

            Score.text = "Score: " + (int)score;

            livess.text = "" + lives;

            Vector3 pos = transform.position;

            //CHANGES X AND Y COORDINATES BASED ON KEY INPUT, ESSENTIALLY MOVE CONTROLS OF PLAYER
            if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)) {
                if(pos.x < 4.8f) {
                    pos.x += speed * Time.deltaTime;
                }
                else {
                    pos.x = 4.8f;
                }
            }
            if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) {
                if(pos.x > -6.7f) {
                    pos.x -= speed * Time.deltaTime;
                }
                else {
                    pos.x = -6.7f;
                }
            }

            this.transform.position = pos;

            timer -= Time.deltaTime;
            
            //CREATES SHOOTER WHEN SPACE BAR, UPWARD ARROW OR S KEY IS PRESSED
            if (Input.GetKey("s") || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) {
                if(timer<=0) { //CREATES DELAY OF 0.2s BEFORE NEXT BULLET IS INSTANTIATED
                    createShooter();
                    timer = 0.2f;
                }
            }
        }

        else if(gameOver()) {

            latestscore = score;
            
            Vector3 pos2 = transform.position;
            pos2.y = 100f;
            this.transform.position = pos2; //MOVES PLAYER OUT OF VISIBILITY

            try { 
                KO.SetActive(true);
                Gtime.SetActive(false);
            }

            catch {
                UnityEngine.Debug.Log("KO and GTime Null");
            }

            //PUSHES THE LATEST HIGH SCORE TO THE SCORE STACK AND ENSURING ONLY ONE COPY IS PUSHED TO STACK
            //ACCESSES AND MUTATES STACK FROM THE scoreScript3 CLASS
            try {
                if(scoreScript3.scorelist.Count == 0 || (int)scoreScript3.scorelist.Peek() != (int)latestscore) {
                    if(scoreScript3.scorelist.Count != 0) {
                        UnityEngine.Debug.Log("pushing to stack " + (int)scoreScript3.scorelist.Peek() + " pushing: " + (int)latestscore);
                    }
                    scoreScript3.scorelist.Push(latestscore);
                }
            }

            catch (NullReferenceException e) {
                UnityEngine.Debug.Log("Movecontrols class not Instantiated (Yet):  " + e);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //IF PLAYER COLLIDES WITH AN ENEMY OBJECT (BASED ON IT'S TAG), LIVES DECREASE
        if(collision.gameObject.tag == "normall_skull" || collision.gameObject.tag == "scary_skull" || collision.gameObject.tag == "winged") {
            Destroy(collision.gameObject);
            lives--;
        }
    }

    void Awake() {
        GameObject[] objects_player = GameObject.FindGameObjectsWithTag("Player"); //CREATES ARRAYS OF OBJECTS THAT CONTAIN ALL REPETITIONS OF THE PLAYER AND CANVAS OBJECTS AS REPEAT INSTANTIATIONS SOMETIMES OCCUR WHEN A SCENE IS LOADED MULTIPLE TIMES AND THE DontDestroyOnLoad() FUNCTION HAS BEEN APPLIED (SEE LINES 199 - 201)
        GameObject[] objects_canvas = GameObject.FindGameObjectsWithTag("Canvas");

        try {
            for(int i = 0; i < objects_player.Length; i++) {
                if(objects_player[i] != this.gameObject) {
                    Destroy(objects_player[i]); //DESTRUCTOR FOR OTHER OBJECTS, CAN'T DESTROY THIS ONE AND KEEP ANOTHER COPY AS THIS ONE WILL CONTAIN DEFINITIONS FOR MOST PUBLIC OBJECTS DECLARED BEFORE THE void Start() FUNCTION
                }
            }
            UnityEngine.Debug.Log("Repeated Instantiations of Player Destroyed");
        }

        catch {
            UnityEngine.Debug.Log("Multiple Player Objects not Instantiated");
        }

        try {
            for(int i = 0; i < objects_canvas.Length; i++) {
                if(objects_canvas[i] != DontDestroy) {
                    Destroy(objects_canvas[i]);
                }
            }
            UnityEngine.Debug.Log("Repeated Instantiations of Canvas Destroyed");
        }

        catch {
            UnityEngine.Debug.Log("Multiple Canvas Objects not Instantiated");
        }

        //MAKES SURE THESE OBJECTS DO NOT GET DESTROYED ONCE NEW SCENE LOADS USING PRE-BUILT UNITY FUNCTION
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(this.GetComponent<movecontrols>());
        DontDestroyOnLoad(DontDestroy);
    }
}
