using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed = 3.8f;
    float height = 0.001f;

    void Update()
    {
        //SAME LOGIC APPLIED AS COMMENTED IN THE CLASS: Movement_Top 

        Vector3 pos = transform.position;
        float newY = Mathf.Sin(Time.time * speed) * height;
        float newX = Mathf.Cos(Time.time * 1.1f * speed) * height;
        
        //UnityEngine.Debug.Log("PosY: " + newY);
        transform.position = new Vector3(pos.x + newX, pos.y + newY, pos.z);
    }
}
