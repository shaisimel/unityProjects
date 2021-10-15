using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] float arrowSpeed = 5f;
    PlayerMovment player;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovment>();
        arrowSpeed = player.transform.localScale.x * arrowSpeed;
        transform.localScale = new Vector2(player.transform.localScale.x, transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2d.velocity = new Vector2(arrowSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Enemy")) {
            Destroy(collision.gameObject);
        }
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(this.gameObject);
    }
}
