using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Check : MonoBehaviour
{
    //THIS CLASS MAKES SURE THAT ALL OBJECTS ARE BEHAVING APPROPRIATELY
    //BASICALLY ENSURES THAT OBJECTS ON WHICH THE DontDestroyOnLoad() FUNCTION HAS BEEN APPLIED DO NOT SHOW UP IN OTHER SCENES
    Scene currentScene;
    private int buildIndex;

    void Awake()
    {
        Vector3 pos = transform.position;
        pos.y = -100f;

        currentScene = SceneManager.GetActiveScene();
        buildIndex = currentScene.buildIndex;

        if(buildIndex != 2) { //IF THE CURRENT SCENE IS NOT THE GAME SCENE, MOVE ANY PLAYER OBJECTS AWAY AND DEACTIVATE THE GUI COMPONENTS FOR THE GAME SCENE
            try {
                GameObject[] objects_player = GameObject.FindGameObjectsWithTag("Player");
                GameObject[] objects_canvas = GameObject.FindGameObjectsWithTag("Canvas");

                for(int i = 0; i < objects_player.Length; i++) {
                    objects_player[i].transform.position = pos;
                }

                for(int i = 0; i < objects_canvas.Length; i++) {
                    objects_canvas[i].SetActive(false);
                }
            }
            catch {
                UnityEngine.Debug.Log("Game Scene Objects Not Yet Loaded");
            }
        }

        if(buildIndex != 0) { //DEACTIVATES SOME GUI COMPONENTS THAT SHOULD NOT APPEAR IN SCENES OTHER THAN THE FIRST
            try {
                GameObject.FindWithTag("Background").SetActive(false);
            }
            catch {
                UnityEngine.Debug.Log("First Scene Objects Not Yet Loaded");
            }
        }
    }
}
