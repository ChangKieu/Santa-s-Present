using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    public AudioSource hurt,plus,gameover;
    
    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] bool moveLeft, moveRight, moveUp;


    Health health;
    private enum MovementState { idle, walk, jump, fall }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        health= GameObject.FindGameObjectWithTag("Health").GetComponent<Health>();
    }

    private void Update()
    {
        if(health.healthCount==0)
        {
            gameover.Play();
            gameObject.SetActive(false);
            GetComponent<Player>().enabled = false;
        }
        dirX = Input.GetAxisRaw("Horizontal");
        
        if(moveLeft)
        {
            dirX = -1;
        }
        if(moveRight)
        {
            dirX = 1;
        }
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if ((Input.GetButtonDown("Jump") ) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimation();
    }
    public void Jump()
    {
        if(IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private void UpdateAnimation()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.walk;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.walk;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }

        anim.SetInteger("state", (int)state);
    }


    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    public void PointerDownLeft()
    {
        moveLeft = true;
    }
    public void PointerUpLeft()
    {
        moveLeft = false;
    }
    public void PointerDownRight()
    {
        moveRight = true;
    }
    public void PointerUpRight()
    {
        moveRight = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            hurt.Play();
            health.healthCount--;
            sprite.material.color= new Color(200.0f, 1.0f, 1.0f, 0.5f); 
            Invoke("ChangeColor", 0.3f);
        }
        if (collision.CompareTag("Present"))
        {
            plus.Play();
        }    
            if (collision.CompareTag("Deadzone"))
        {
            health.healthCount = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            hurt.Play();
            health.healthCount--;
            sprite.material.color = new Color(200.0f, 1.0f, 1.0f, 0.5f);
            Invoke("ChangeColor", 0.3f);
        }
        if (collision.gameObject.CompareTag("Present"))
        {
            plus.Play();
        }
    }
    private void ChangeColor()
    {
        sprite.material.color = Color.white;
    }
}
