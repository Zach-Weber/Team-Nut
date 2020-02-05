/******************************
 * PlayerController.cs
 * By: Conor Brennan
 * Last Edited: 2/3/2020
 * Description: gives player forward movement at game start and controls jumping
 ******************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myRB;
    public float speed = 5f;
    public float jumpSpeed = 1f;
    public bool started = false;
    public bool jumped = false;
    public bool grounded = true;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(started == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
                jumped = true;
            }
            if (myRB.position.y <= -1.99f && jumped == true)
            {
                started = true;
                Debug.Log("Started");
            }
        }
        //gives player forward movement
        if (started == true)
        {
            Vector3 newVel = myRB.velocity;
            newVel.x = speed;
            myRB.velocity = newVel;  
        }

        //checks if player is on ground
        if (myRB.velocity.y == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Jump();
        }
                
        void Jump()
        {
            {
                //creates new vector for jump movement
                Vector3 jumpMovement = new Vector3(0.0f, 1.0f, 0.0f);
                //sets player velocity to jumpmovement * jumpspeed
                myRB.velocity = jumpMovement * jumpSpeed;
                grounded = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //checks if player collided with a cactus
        if (collision.collider.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
            started = false;
            jumped = false;
        }
    }
}
