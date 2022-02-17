using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoscores : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene(3); //LOADS SCORE PAGE
    }
}
