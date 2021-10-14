using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rigidbody2d;
    Animator animator;
    CapsuleCollider2D bodyCollider2d;
    BoxCollider2D feetCollider2d;
    int groundLayerIndex;
    int climbingLayerIndex;
    float playerGravityScale;
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float climbSpeed = 5f;
    bool isAlive = true;
    
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bodyCollider2d = GetComponent<CapsuleCollider2D>();
        groundLayerIndex = LayerMask.GetMask("Ground");
        climbingLayerIndex = LayerMask.GetMask("Climbing");
        playerGravityScale = rigidbody2d.gravityScale;
        feetCollider2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isAlive) return;

        Run();
        FlipSprite();
        climbLadder();
    }

    void FlipSprite() {
        if (isPlayerRunning()) {
            transform.localScale = new Vector2(Mathf.Sign(rigidbody2d.velocity.x), transform.localScale.y);
        }
    }

    void OnMove(InputValue input) {
        if (!isAlive) return;
        moveInput = input.Get<Vector2>();
    }

    void Run() {
        rigidbody2d.velocity = new Vector2(moveInput.x * runSpeed, rigidbody2d.velocity.y);
        animator.SetBool("isRunning", isPlayerRunning());
    }

    bool isPlayerRunning() {
        return Mathf.Abs(rigidbody2d.velocity.x) > Mathf.Epsilon;
    }

    void climbLadder() {
        if (feetCollider2d.IsTouchingLayers(climbingLayerIndex)) {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, moveInput.y * climbSpeed);
            rigidbody2d.gravityScale = 0f;
        } else {
            rigidbody2d.gravityScale = playerGravityScale;
        }
        animator.SetBool("isClimbing", isClimbingLadder());
    }

    bool isClimbingLadder() {
        return feetCollider2d.IsTouchingLayers(climbingLayerIndex) && Mathf.Abs(rigidbody2d.velocity.y)>Mathf.Epsilon;
    }

    void OnJump(InputValue input) {
        if (!isAlive) return;
        if (input.isPressed && feetCollider2d.IsTouchingLayers(groundLayerIndex)) {
            rigidbody2d.velocity += new Vector2(0, jumpHeight);
     
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //Debug.Log("colided - " + collision.gameObject.tag);
        if (collision.gameObject.tag.Equals("Enemy")) {
            Die();
        }
    }

    void Die() {
        moveInput = new Vector2(0f, 0f);
        isAlive = false;
    }
}
