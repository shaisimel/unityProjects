using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class trampoline : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue input) {
        Vector2 moveInput = input.Get<Vector2>();
        rigidbody2d.velocity = new Vector2(moveInput.x * moveSpeed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
