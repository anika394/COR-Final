using System.Threading;
using System.Numerics;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChar : MonoBehaviour
{   
    public bool check = true;
    void Update()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>(); //ACCESSES COLOR COMPONENT OF CHARACTER
        float newY = Mathf.Sin(Time.time*1f); //CREATES SINE FUNCTION FOR TIME PASSES, ENSURING CONTINUOUS ANIMATION LOOP AS RANGE IS BETWEEN -1 AND 1

        if(check == true) //FOLLOWING LINES ACCESS AND MUTATE COLOR/RENDER COMPONENT OF CHARACTER/OBJECT
        {
            if(newY>0.995f)
                renderer.material.color = Color.clear;
            else if(newY>0.98)
                renderer.material.color = new Color(0.21f, 0.21f, 0.21f, 1f);
            else
                renderer.material.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public void Darken() 
    {
        check = false;
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.material.color = new Color(0.21f, 0.21f, 0.21f, 1f);
    }

    void OnMouseOver()
    {
        Darken();
        UnityEngine.Debug.Log("mouse hovering on object, animation triggered");
    }

    void OnMouseExit()
    {
        check = true;
        UnityEngine.Debug.Log("mouse not over object, normal state");
    }
}