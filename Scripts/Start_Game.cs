using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Game : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Load Scene");
    }
    public void OnMouseDown()
    {
        SceneManager.LoadScene(1); //SWITCH SCENES BASED ON MOUSE INPUT TO INFO SCENE WITH INDEX 1
    }
}
