using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Top : MonoBehaviour
{
    float speed = 4.6f;
    float height = 0.001f;
    float height_two = 0.003f;

    void Update()
    {
        //THE FOLLOWING CODE CREATES A REPEATED/LOOPED ANIMATION FOR THE THREE FLYING OBJECTS ATTACHED OT THE CHARACTER

        Vector3 pos = transform.position;

        float newY = Mathf.Sin(Time.time * -speed) * height;
        float newX = Mathf.Cos(Time.time * 1.1f * -speed) * height;

        if(gameObject.tag=="Ghost") {
            UnityEngine.Debug.Log("Ghost");
            newY = Mathf.Sin(Time.time * speed) * height_two;
            newX = Mathf.Cos(Time.time * 1.1f * -speed) * height_two;
        }
        //UnityEngine.Debug.Log("PosY: " + newY);
        transform.position = new Vector3(pos.x + newX, pos.y + newY, pos.z); //CONTINUOUSLY UPDATES THE POSITION OF THE OBJECTS AS THE FUNCTION: void Update() RUNS EVERY FRAME
    }
}
