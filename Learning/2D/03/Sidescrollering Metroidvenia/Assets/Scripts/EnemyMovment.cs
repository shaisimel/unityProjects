using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] float moveSpeed = 1f;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2d.velocity = new Vector2(moveSpeed, 0f);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(!collision.gameObject.tag.Equals("Player")) {
            moveSpeed *= -1;
            transform.localScale = new Vector2(-(Mathf.Sign(rigidbody2d.velocity.x)), transform.localScale.y);
        }
    }
}
