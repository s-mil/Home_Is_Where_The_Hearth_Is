using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this class handles player movement (i.e walking, jumping, and dashing
public class PlayerController : MonoBehaviour
{  //initialize global variables and flags
    bool moveLeft;
    bool moveRight;
    Rigidbody2D rb;
   public float moveSpeed = 1.0f;
    bool jump;
    public float jumpForce = 1.0f;

    public float maxSpeed = 1.0f;

    bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {  //initialize flags and rigidbody
        rb = GetComponent<Rigidbody2D>();
        moveLeft = false;
        moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        //sets flags for input on left and right and jump button
        if (Input.GetAxis("Horizontal") > 0)
        {
            moveRight = true;
            
        } else
        {
            moveRight = false;
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }

        if (Input.GetAxis("Jump") > 0)
        {
            jump = true;
        }
        else
        {
            jump = false;
        }





    }

    void FixedUpdate()
    { //This method updates force depending on user keypress
        if (moveRight == true)
        {
            if (grounded == true)
            {
                rb.AddForce(transform.right * moveSpeed);
            }
            
            if (grounded == false)
            {
                rb.AddForce(transform.right * (moveSpeed/4));
            }
        }
        if (moveLeft == true)
        {
            if (grounded == true)
            {
                rb.AddForce(transform.right * -1 * moveSpeed);
            }
            if (grounded == false)
            {
                rb.AddForce(transform.right * -1 * (moveSpeed/4));
            }
        }
        if (jump == true && grounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }

        if (rb.velocity.magnitude > maxSpeed && grounded)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }


    }

    
   

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
       
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = false;
        }

    }

}


