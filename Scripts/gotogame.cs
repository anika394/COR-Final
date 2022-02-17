using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotogame : MonoBehaviour
{
    movecontrols scoreScript = null;
    GameObject GO2;
    Vector3 pos;

    void Start() {
        pos = new Vector3(0.51f, -2.96f, -1.55f); //ORIGINAL POSITION OF PLAYER

        try {
            GO2 = GameObject.FindWithTag("Player"); //GETS PLAYER OBJECT AND IT'S ASSIGNED CLASS IF IT HAS BEEN LOADED
            scoreScript = GO2.GetComponent<movecontrols>();
        }
        catch {
            UnityEngine.Debug.Log("Not Yet Loaded");
        }
    }

    public void OnMouseDown()
    {
        SceneManager.LoadScene(2); //SWITCHES SENE ONCE MOUSE IS PRESSED OVER THIS OBJECT (i.e. BUTTON)
    
        try {
            //RESETS VALUES OF GAME IF LOADED, THROWS AN ERROR IF NOT, THUS THE NEED FOR THE TRY CATCH STATEMENT
            scoreScript.score = 0f;
            scoreScript.gameTime = 15.0f;
            scoreScript.lives = 13;
            GO2.transform.position = pos;
            scoreScript.KO.SetActive(false);
            scoreScript.Gtime.SetActive(true);
        }
        catch {
            UnityEngine.Debug.Log("Not Yet Loaded");
        }
    }
}