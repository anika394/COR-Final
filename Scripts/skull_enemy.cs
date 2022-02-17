using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skull_enemy : MonoBehaviour
{
    float speed = 1.5f;

    void Update()
    {
        //MOVES THE ENEMIES DOWN THE SCREEN AND DESTROYS AFTER 10 SECONDS
        
        Vector3 pos = transform.position;
        pos.y -= speed * Time.deltaTime;
        this.transform.position = pos;

        speed += 0.9f * Time.deltaTime;

        Destroy(this, 10);
    }
}
