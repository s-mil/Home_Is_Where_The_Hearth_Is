using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{

    public float minGroundNormalY = .65f;
    public float gravityModifier = 1f;
    public Vector2 targetVelocity;
    public  bool grounded;
    protected Vector2 groundNormal;
    protected Rigidbody2D rb2d;
    protected Vector2 velocity;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);
    public float wallDirection = 0.0f;
    public bool touchIce;
    public AudioSource jump;
    public AudioSource dash;

    public bool onRope;

    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;
    public bool walljump;

    public bool right;
    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    void Update()
    {
        targetVelocity = Vector2.zero;
        ComputeVelocity();
         if (Input.GetButtonDown("Jump") && grounded)
        {
            jump.Play();
        }
        if(Input.GetButtonDown("Fire3"))
        {
            dash.Play();
        }
    }

    protected virtual void ComputeVelocity()
    {

    }

    void FixedUpdate()
    {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;

        velocity.x = targetVelocity.x;

        grounded = false;

        Vector2 deltaPosition = velocity * Time.deltaTime;

        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement(move, false);

        move = Vector2.up * deltaPosition.y;

        Movement(move, true);
    }

    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > minMoveDistance)
        {
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
            hitBufferList.Clear();
            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal;
                if (currentNormal.y > minGroundNormalY)
                {
                    grounded = true;
                    if (yMovement)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(velocity, currentNormal);
                if (projection < 0)
                {
                    velocity = velocity - projection * currentNormal;
                }

                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }
        rb2d.position = rb2d.position + move.normalized * distance;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "wall")
        {
            Collider2D collider = collision.collider;
            walljump = true;
           

            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collider.bounds.center;

             right = contactPoint.x > center.x;

        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            walljump = false;
            
        }

        if (collision.gameObject.tag == "ice")
        {
            touchIce = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ice")
        {
            touchIce = true;
        }

        if (collision.gameObject.tag == "movingPlatform" && Input.GetAxis("Horizontal") < 0.1f && Input.GetAxis("Horizontal") > -0.1f && !Input.GetButton("Jump") && !Input.GetButton("Fire3")){
            transform.parent = collision.transform.parent;
        } else {
            transform.parent = null;
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "rope"){
            onRope = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "rope"){
            onRope = false;
        }
    }
}
