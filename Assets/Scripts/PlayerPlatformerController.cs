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
    private Animator animator;
    private bool facingRight;

    float tempgravity;
    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        canDash = true;
        facingRight = true;
        isWallJumping = false;
    }

    protected override void ComputeVelocity()
    {
        
        Vector2 move = Vector2.zero;

        if (!isDashing) {
            move.x = Input.GetAxis("Horizontal");
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
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

        if (walljump &&  !grounded)
        {
            tempgravity = gravityModifier;
            gravityModifier = gravityModifier/2;
        }

        else
        {
            Debug.Log("set it back");
            gravityModifier = 5;
        }



        if (move.x > 0.01f){
            facingRight = true;
            spriteRenderer.flipX = false;
        } else if (move.x < -0.01f){
            facingRight = false;
            spriteRenderer.flipX = true;
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

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



   





}
