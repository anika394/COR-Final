using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartonR : MonoBehaviour
{
    movecontrols scoreScript = null; //USED TO ACCESS COMPONENTS FROM OTHER CLASSES
    GameObject GO2; //USED TO ACCESS COMPONENTS OR CLASSES ATTACH TO THE OBJECT
    Vector3 pos;


    void Start() {
        GO2 = GameObject.FindWithTag("Player"); //GETS PLAYER OBJECT AND IT'S ASSIGNED CLASS IF IT HAS BEEN LOADED
        scoreScript = GO2.GetComponent<movecontrols>(); //ACCESSES THE CLASS FROM HERE BECAUSE THE CLASS IS ATTACHED TO THE OBJECT IN MY UNITY EDITOR
        pos = new Vector3(0.51f, -2.96f, -1.55f);
    }

    void Update()
    {
        if (Input.GetKey("r")) {
            //BASICALLY RESTARTS ALL THE SETTINGS WHEN 'R' IS PRESSED AND LOADS THE SCENE AGAIN
            //RESETS VALUES OF GAME IF LOADED, THROWS AN ERROR IF NOT, THUS THE NEED FOR THE TRY CATCH STATEMENT
            SceneManager.LoadScene(2);
            try {
                scoreScript.score = 0f;
                scoreScript.gameTime = 15.0f;
                scoreScript.lives = 13;
                GO2.transform.position = pos;
                scoreScript.KO.SetActive(false);
                scoreScript.Gtime.SetActive(true);
            }

            catch {
                UnityEngine.Debug.Log("Game Objects Issue on Restart R");
            }
        }
    }
}
