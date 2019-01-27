using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public bool isDashing;
    public bool isWallJumping;
    public bool wallSide;
    public bool canDash;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private bool facingRight;
    public float holdSpeed;
    public bool isSliding;
    public bool noSlideYet;

    float tempgravity;
    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        canDash = true;
        facingRight = true;
        isWallJumping = false;
        isSliding = false;
    }

    protected override void ComputeVelocity()
    {
        gravityModifier = 5;
        Vector2 move = Vector2.zero;

        if(onRope){
            grounded = true;
        }

        if (touchIce && !isSliding && Input.GetAxis("Horizontal") < 0.01f && Input.GetAxis("Horizontal") > -0.01f && !noSlideYet)
        {
            isSliding = true;
            StartCoroutine(Slide());
            noSlideYet = true;
        }
        else if (isSliding)
        {
            if (facingRight)
            {
                move.x = 0.5f;
            } else
            {
                move.x = -0.5f;
            }
        }
        else if (!isDashing) {
            move.x = Input.GetAxis("Horizontal");
            //holdSpeed = move.x;
        } 

        if (Input.GetButtonDown("Jump") && grounded)
        {
            anim.SetTrigger("hasJumped");
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if (Input.GetButtonDown("Jump") && !grounded && walljump)
        {
            wallSide = right;
            
            if (isWallJumping)
            {
                StopCoroutine(WallJump());
                isWallJumping = false;
            }
            StartCoroutine(WallJump());
        }
        



        if (move.x > 0.1f){
            anim.SetTrigger("isWalking");
            facingRight = true;
            spriteRenderer.flipX = false;
            noSlideYet = false;
            if (isSliding)
            {
                StopCoroutine(Slide());
            }
        } else if (move.x < -0.1f){
            anim.SetTrigger("isWalking");
            facingRight = false;
            spriteRenderer.flipX = true;
            noSlideYet = false;
            if (isSliding)
            {
                StopCoroutine(Slide());
            }
        } else
        {
            anim.SetTrigger("isStopped");
            noSlideYet = true;
        }

        if (Input.GetButtonDown("Fire3") && !isDashing && canDash)
        {
            canDash = false;
            gravityModifier = 0;
            StartCoroutine(Dash());
            StartCoroutine(dashCooldown());
        }

        if (isDashing) {
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            velocity.y = 0;
            if(facingRight){
                targetVelocity = new Vector2(1,0) * maxSpeed * 2.5f;
            } else {
                targetVelocity = new Vector2(1,0) * maxSpeed * 2.5f * -1;
            }
        } else if (isWallJumping)
        {
            if (wallSide)
            {
                velocity.y = jumpTakeOffSpeed * 1.25f;
                targetVelocity = new Vector2(1, 0) * maxSpeed * -1;
            }
            else
            {
                velocity.y = jumpTakeOffSpeed * 1.25f;
                targetVelocity = new Vector2(1, 0) * maxSpeed * 1;
            }
        }
        else
        {
            targetVelocity = move * maxSpeed;
        }
    }

    protected IEnumerator WallJump()
    {
        isWallJumping = true;
        yield return new WaitForSeconds(0.2f);
        isWallJumping = false;
    }

    protected IEnumerator Dash()
    {
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(0.025f);
        isDashing = true;
        yield return new WaitForSeconds(0.15f);
        isDashing = false;
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    IEnumerator dashCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        canDash = true;
    }

    protected IEnumerator Slide()
    {
        isSliding = true;
        yield return new WaitForSeconds(.25f);
        isSliding = false;
    }







}
