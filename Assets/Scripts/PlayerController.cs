using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool moveLeft;
    bool moveRight;
    Rigidbody2D rb;
   public float moveSpeed = 1.0f;
    bool jump;
    public float jumpForce = 1.0f;

    public float maxSpeed = 1.0f;

    bool grounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveLeft = false;
        moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
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
    {   if (moveRight == true)
        {
            if (grounded == true)
            {
                rb.AddForce(transform.right * moveSpeed);
            }
            
            if (grounded == false)
            {
                rb.AddForce(transform.right * (moveSpeed/2));
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
                rb.AddForce(transform.right * -1 * (moveSpeed/2));
            }
        }
        if (jump == true && grounded == true)
        {
            rb.AddForce(transform.up * jumpForce);
        }

        if (rb.velocity.magnitude > maxSpeed && grounded == true)
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


