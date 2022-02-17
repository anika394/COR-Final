using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score_Page : MonoBehaviour
{
    //ALL THE PUBLIC TEXT OBJECTS HANDLE THE GUI PARTS OF THIS SCENE, THEY ARE ASSIGNED THE ACTUAL TEXT OBJECTS IN UNITY EDITOR
    public Text HighScore;
    public Text AverageScore;
    public Text listleft;
    public Text listright;

    private float HighScoreVal = 0f;
    private float AverageScoreVal = 0f;

    private string scoreformat1 = "1 \t" + "\n2 \t" + "\n3 \t" + "\n4 \t" + "\n5 \t";
    
    private string scoreformat2 = "6 \t" + "\n7 \t" + "\n8 \t" + "\n9 \t" + "\n10\t";

    private int gamecount = 1;
    private float sumscore = 0;

    movecontrols scoreScript2 = null; //TO ACCESS OTHER CLASSES, INSTANTIATES THIS
    ScoreStack scoreScript3 = null;
    float max = 0f;

    Scene currentScene; //SCENE OBJECT BASICALLY RETURNS WHICH SCENE IS CURRENTLY IN PROGRESS, DONE SO IN LINE 36
    private int buildIndex; //DECLARED AN INT WHICH WILL LATER HOLD THE INDEX OF THE SCENE IN LINE 37

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        buildIndex = currentScene.buildIndex;

        HighScore.text = "" + (int)HighScoreVal; //ACCESSES AND MUTATES THE 'text' PROPERTY OF THE TEXT OBJECT - HighScore
        AverageScore.text = "" + (int)AverageScoreVal;

        GameObject GO2 = GameObject.FindWithTag("Player"); //DECLARED AND ASSIGNED OBJECT BASED ON A TAG - A STRING ASSIGNED TO AN ALREADY CREATED OBJECT IN THE EDITOR
        GameObject GO4 = GameObject.FindWithTag("Canvas");
        GameObject GO5 = GameObject.FindWithTag("ScoreStack");

        try {
            GO4.SetActive(false); //MAKES THE GAMEOBJECT "INVISIBLE", IT CAN'T BE SEEN BUT IT ISN'T DESTRUCTED, PUT IN TRY CATCH STATEMENT BECAUSE IT MIGHT NOT HAVE BEEN INSTANTIATED YET AND WILL THROW A NULL REFERENCE ERROR (SAME LOGIC FOR THE FOLLOWING TRY CATCH STATEMENTS)
        }

        catch (NullReferenceException e) {
            UnityEngine.Debug.Log("KO Object not Instantiated (Yet):  " + e);
        }

        try {
            scoreScript2 = GO2.GetComponent<movecontrols>();
        }

        catch (NullReferenceException e) {
            UnityEngine.Debug.Log("Player Object not Instantiated (Yet):  " + e);
        }

        try {
            scoreScript3 = GO5.GetComponent<ScoreStack>();
        }

        catch (NullReferenceException e) {
            UnityEngine.Debug.Log("ScoreStack Object not Accessed:  " + e);
        }
    }

    void Update()
    {
        scoreformat1 = "";
        scoreformat2 = "";

        sumscore = 0;
        gamecount = 1;

        foreach (float value in scoreScript3.scorelist) {
            //ITERATES OVER THE STACK CONTAINING ALL THE SCORES FROM THE ScoreStack CLASS, THIS DIDN'T NEED A TRY CATCH BECAUSE I INSTANTIATED THE OBJECT CONTAINING THIS CLASS AT THE START

            UnityEngine.Debug.Log("Value: " + value);

            if(value>=max) {
                max = value;
            }
            sumscore += value;

            //FORMATTING AS THE LIST OF THE 10 MOST RECENT SCORES IS SPLIT INTO TWO TEXT OBJECTS: 1 TO 5, AND 6 TO 10

            if(gamecount <= 5) {
                scoreformat1 += gamecount + "     \t" + value +"\n";
                UnityEngine.Debug.Log("SF: " + scoreformat1);
            }

            else if(gamecount > 5 && gamecount <10) {
                scoreformat2 += gamecount + "     \t" + value +"\n";
                UnityEngine.Debug.Log("SF: " + scoreformat2);
            }

            else if(gamecount == 10) {
                scoreformat2 += gamecount + "\t" + value +"\n";
                UnityEngine.Debug.Log("SF: " + scoreformat2);
                break;
            }

            else
                break;

            gamecount++;
        }

        if(sumscore > 0) {
            AverageScoreVal = sumscore/(scoreScript3.scorelist.Count);
        }
        HighScoreVal = max;

        try {
            if(HighScore != null) HighScore.text = "" + (int)HighScoreVal;
            if(AverageScore != null) AverageScore.text = "" + (int)AverageScoreVal;

            if(listleft != null) listleft.text = scoreformat1; //FORMATTING SCORES
            if(listright != null) listright.text = scoreformat2;
        }

        catch {
            UnityEngine.Debug.Log("Text Objects not Instantiated (Yet)");
        }
    }

    void Awake() {
        
        GameObject[] objects_sample = GameObject.FindGameObjectsWithTag("sample"); //CREATES ARRAY OF ALL THE OBJECTS WITH THE TAG

        if (objects_sample.Length > 1)
        {
            //DESTROYS REPEATED INSTANTIATIONS OF THE SAME OBJECT WHICH ARE REDUNDANT
            try {
                for(int i = 0; i < objects_sample.Length; i++) {
                    if(objects_sample[i] != this.gameObject) {
                        Destroy(objects_sample[i]); //DESTRUCTOR FOR OBJECTS
                    }
                }
                UnityEngine.Debug.Log("Repeated Instantiations Destroyed");
            }

            catch {
                UnityEngine.Debug.Log("Text Objects not Instantiated (Yet)");
            }
        }

        //IN EVERY SCENE, ONCE A NEW SCENE IS LOADED THE OBJECTS IN THAT SCENE ARE DESTROYED 
        //THIS FUNCTION RETAINS THEM ACROSS ALL SCENES UNLESS STATED OTHERWISE
        DontDestroyOnLoad(this.gameObject); 
    }
}