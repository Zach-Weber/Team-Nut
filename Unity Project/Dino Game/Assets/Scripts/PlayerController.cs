/******************************
 * PlayerController.cs
 * By: Conor Brennan
 * Last Edited: 2/7/2020
 * Description: gives player forward movement at game start and controls jumping
 ******************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    Animator myAnim;
    Rigidbody2D myRB;
    public float speed = 5f;
    public float jumpSpeed = 1f;
    public static bool started = false;
    public static bool jumped = false;
    public static bool grounded = true;
    public static bool crouching = false;
    public static bool dead;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMoveState();
        if(started == false && grounded == true && dead != true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
                jumped = true;
            }
            if (jumped == true && grounded == true)
            {
                started = true;
                Debug.Log("Started");
            }
        }
        //gives player forward movement
        if (started == true && dead != true)
        {
            Vector3 newVel = myRB.velocity;
            newVel.x = speed;
            myRB.velocity = newVel;  
        }

        //checks if player is on ground and not dead
        if (grounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
                
            else
            {
                if (dead != true)
                {
                    if (Input.GetKey(KeyCode.DownArrow) == true)
                    {
                        crouching = true;
                        Debug.Log("Crouching");
                    }
                    else if (Input.GetKey(KeyCode.DownArrow) != true)
                    {
                        crouching = false;
                    }
                }

            }       
        }

        if (dead == true)
        {
            myRB.isKinematic = true;
            myRB.velocity = new Vector3(0, 0, 0);
        }
           
        else if (dead == false)
            myRB.isKinematic = false;
    }

    void Jump()
    {
        if ( dead != true)
        {
            //creates new vector for jump movement
            SoundManager.PlaySound("Jump");
            Vector3 jumpMovement = new Vector3(0.0f, 1.0f, 0.0f);
            //sets player velocity to jumpmovement * jumpspeed
            myRB.velocity = jumpMovement * jumpSpeed;
            grounded = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);
        if (collision.collider.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        //checks if player collided with a cactus
        if (collision.collider.gameObject.tag == "Obstacle")
        {
            SoundManager.PlaySound("Hit");
            dead = true;
            //Destroy(gameObject);
            started = false;
            jumped = false;
        }
    }

    private void ChangeMoveState()
    {
        //state 0 is jumping
        if (started == true && grounded == false)
            myAnim.SetInteger("State", 0);

        //state 1 is running
        else if (started == true && grounded == true && crouching == false)
            myAnim.SetInteger("State", 1);

        //state 2 is crouching
        else if (crouching == true)
            myAnim.SetInteger("State", 2);

        //state 3 is death
        else if (dead == true)
            myAnim.SetInteger("State", 3);
    }

}
