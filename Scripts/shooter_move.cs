using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter_move : MonoBehaviour
{
    public float bulletspeed = 50.0f;
    movecontrols scoreScript = null; //CREATES NULL OBJECT FOR ACCESSING OTHER CLASS
    
    void Start() {
        GameObject GO = GameObject.FindWithTag("Player"); //ACCESS CHARACTER OBJECT
        scoreScript = GO.GetComponent<movecontrols>(); //ACCESS MOVECONTROLS CLASS
    }

    void Update()
    {
        Vector3 bulletpos = transform.position;  //NEW VECTOR3, IN THE FORM OF A COORDINATE IN 3D SPACE TO MANIPULATE POSITION OF THE BULLETS WHEN THEY ARE SHOT
        bulletpos.y += bulletspeed * Time.deltaTime; //INCREASES BULLET SPEED WITH TIME, ACCELERATES
        this.transform.position = bulletpos;

        Destroy(this, 1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);

        if (collision.gameObject.tag == "normall_skull" || collision.gameObject.tag == "scary_skull" || collision.gameObject.tag == "winged") {
            Destroy(collision.gameObject);
            scoreScript.score += 10.0f; //IF AN ENEMY (OBJECT WITH THE APPROPRIATE TAG) IS HIT, INCREASE THE SCORE VARIABLE FROM THE movecontrols CLASS
        }
        Debug.Log("enemy object destructed or destroyed");
    }
}