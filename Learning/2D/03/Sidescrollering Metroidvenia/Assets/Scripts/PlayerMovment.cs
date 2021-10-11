using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rigidbody2d;
    Animator animator;
    [SerializeField] float runSpeed = 5f;
    
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
    }

    void FlipSprite() {
        if (isPlayerRunning()) {
            transform.localScale = new Vector2(Mathf.Sign(rigidbody2d.velocity.x), transform.localScale.y);
        }
    }

    void OnMove(InputValue input) {
        moveInput = input.Get<Vector2>();
        //Debug.Log(moveInput);
    }

    void Run() {
        rigidbody2d.velocity = new Vector2(moveInput.x * runSpeed, rigidbody2d.velocity.y);
        animator.SetBool("isRunning", isPlayerRunning());
    }

    bool isPlayerRunning() {
        return Mathf.Abs(rigidbody2d.velocity.x) > Mathf.Epsilon;
    }
}
