using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movment : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField] float jumpHeight = 1f;    
    CapsuleCollider2D colider;
    bool isAlive;
    GameManager gameManager;


    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        colider = GetComponent<CapsuleCollider2D>();
        gameManager = FindObjectOfType<GameManager>();
        isAlive = true;
    }

    void OnJump(InputValue input) {

        //body.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
        if (isAlive) {
            body.velocity = new Vector2(0f, jumpHeight);
        } else {
            StartCoroutine(gameManager.reload());
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!isAlive) return;

        if (collision.tag.Equals("Gate")) {
            gameManager.IncreasScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag.Equals("obsticale")) {
            isAlive = false;
            colider.enabled = false;
            gameManager.Die();
        }
    }
}
