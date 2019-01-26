using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public bool isDashing;
    public bool canDash;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool facingRight;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        canDash = true;
        facingRight = true;
    }

    protected override void ComputeVelocity()
    {
        Debug.Log("" + velocity.x);
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
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            StartCoroutine(Dash());
            StartCoroutine(dashCooldown());
        }

        if (isDashing) {
            velocity.y = 0;
            if(facingRight){
                targetVelocity = new Vector2(1,0) * maxSpeed * 2.0f;
            } else {
                targetVelocity = new Vector2(1,0) * maxSpeed * 2.0f * -1;
            }
        } else {
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
            targetVelocity = move * maxSpeed;
            gravityModifier = 5;
        }
    }

    protected override IEnumerator Dash()
    {
        isDashing = true;
        yield return new WaitForSeconds(0.1f);
        isDashing = false;
    }

    IEnumerator dashCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        canDash = true;
    }
    
   






}
