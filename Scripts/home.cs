using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class home : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene(0); //SWITCHES SCENE BASED ON MOUSE INPUT TO FIRST PAGE
    }
}