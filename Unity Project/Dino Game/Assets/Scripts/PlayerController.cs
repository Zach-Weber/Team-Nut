using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myRB;
    public float speed = 5f;
    public float jumpSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newVel = myRB.velocity;
        newVel.x = speed;
        myRB.velocity = newVel;  

        if(transform.position.y < -1.9)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector3 jumpMovement = new Vector3(0.0f, 1.0f, 0.0f);

                myRB.velocity = jumpMovement * jumpSpeed;

                Debug.Log("Jump");
            }
        }
    }
}
