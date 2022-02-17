using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreStack : MonoBehaviour
{
    public Stack<float> scorelist = new Stack<float>(); //PUBLIC SINCE IT NEEDS TO INPUT SCORE DATA FROM OTHER SCRIPT (movecontrols) AND BE ACCESSED BY THE Score_Page CLASS FOR OUTPUTTING THE VALUES

    void Awake() {
        DontDestroyOnLoad(this.gameObject); //RETAINS STACK ACROSS ALL SCENES! SINCE THIS IS IN THE FIRST SCENE LOADED, WILL NOT DESTRUCT AND SCORE VALUES WILL BE SAFE
    }
}
