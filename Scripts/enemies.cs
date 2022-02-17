using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemies : MonoBehaviour
{
    public GameObject Skull;
    public GameObject ScarySkull;
    public GameObject Winged;

    int rows = 2;

    float[] enemy_roster = {1.0f, 6.0f, 6.0f, 9.0f, 1.0f, 9.0f, 6.0f, 6.0f};

    float timer = 0.75f;
    
    void Start()
    {
        Vector3 pos = transform.position;
        float x_pos = -7.0f;
        float y_pos = 3.0f;

        pos.x = x_pos;
        pos.y = y_pos;

        for(int j = 0; j < rows; j++) {
            pos.x = x_pos;
            for(int i = 0; i < enemy_roster.Length; i++) {
                enemy_roster[i] = Random.Range(0f, 12.0f);

                if(enemy_roster[i] < 3.0f) {
                    GameObject instantiatedEnemy = Instantiate(Skull, pos, transform.rotation) as GameObject;
                }
                else if(enemy_roster[i] < 7.0f) {
                    GameObject instantiatedEnemy = Instantiate(ScarySkull, pos, transform.rotation) as GameObject;
                }
                else {
                    GameObject instantiatedEnemy = Instantiate(Winged, pos, transform.rotation) as GameObject;
                }

                pos.x += 1.5f;
            }
            pos.y -= 1.8f;
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0) {
            Vector3 pos = transform.position;
            float x_pos = -7.0f;
            float y_pos = 3.0f;

            pos.x = x_pos;
            pos.y = y_pos;
            
            for(int i = 0; i < enemy_roster.Length; i++) {
                enemy_roster[i] = Random.Range(0f, 12.0f);

                if(enemy_roster[i] < 3.0f) {
                    GameObject instantiatedEnemy = Instantiate(Skull, pos, transform.rotation) as GameObject;
                }
                else if(enemy_roster[i] < 7.0f) {
                    GameObject instantiatedEnemy = Instantiate(ScarySkull, pos, transform.rotation) as GameObject;
                }
                else {
                    GameObject instantiatedEnemy = Instantiate(Winged, pos, transform.rotation) as GameObject;
                }

                pos.x += 1.5f;
            }
            timer = 0.75f - (0.9f * Time.deltaTime);
        }
    }
}
