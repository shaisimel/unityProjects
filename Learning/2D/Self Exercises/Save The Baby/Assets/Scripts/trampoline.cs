using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class trampoline : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector2 moveInput;
    Rigidbody2D rigidbody2d;
    Animator[] childAnimators;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        childAnimators = GetComponentsInChildren<Animator>();
    }

    void OnMove(InputValue input) {
        moveInput = input.Get<Vector2>();
        rigidbody2d.velocity = new Vector2(moveInput.x * moveSpeed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = Mathf.Abs(moveInput.x) > Mathf.Epsilon;
        foreach(Animator ani in childAnimators) {
            ani.SetBool("isWalking", isWalking);
        }
    }
}
