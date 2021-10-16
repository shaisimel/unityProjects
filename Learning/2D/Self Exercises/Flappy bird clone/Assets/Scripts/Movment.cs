using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movment : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField] float jumpHeight = 1f;
    [SerializeField] GameObject gameManagerObject;
    GameManager gameManager;


    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnJump(InputValue input) {
        body.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Gate")) {
            gameManager.IncreasScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag.Equals("obsticale")) {
            gameManager.Die();
        }
    }
}
