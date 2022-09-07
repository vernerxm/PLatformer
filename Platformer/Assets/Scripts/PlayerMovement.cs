using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    private Rigidbody2D rb;
    private Animator anim;
    private float dirx = 0f;
    private SpriteRenderer sprite;
    [SerializeField] private float MoveSpeed = 7f;
    [SerializeField]  private float JumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;
    private enum MovementState { idle,running,jumping,falling};
    private BoxCollider2D coll;
    [SerializeField] private AudioSource JumpSound;
   
   private void Start()

    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

   
   private void Update()
    {
         dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2( dirx * MoveSpeed, rb.velocity.y );

       if (Input.GetButtonDown("Jump") && IsGrounded())
            {
            JumpSound.Play();
           rb.velocity = new Vector2(rb.velocity.x,JumpForce);
        }


       UpdateAnimatoionUpdate();


    }
    private void UpdateAnimatoionUpdate()
    {
        MovementState state;


        if (dirx > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirx < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;

        }
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state",(int) state);
    }


    private bool IsGrounded()
    {
       return  Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f,jumpableGround);
    }



}


