using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMovment : MonoBehaviour
{
    [SerializeField] float movmentSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - (movmentSpeed * Time.deltaTime), transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("despawn")) {
            Destroy(gameObject, 0f);
        }
    }
}
