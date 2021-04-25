using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int jumpforce;
    public int movspeed;
    bool canJump;    

    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && canJump)
        {
            canJump = false;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpforce));
        }

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(movspeed,
            this.GetComponent<Rigidbody2D>().velocity.y);

        if (transform.position.y < -10)
        {
            GameObject.Destroy(this.gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            canJump = true;
        }

        if (collision.transform.tag == "enemy")
        {
            GameObject.Destroy(this.gameObject);
        }

    }

}


