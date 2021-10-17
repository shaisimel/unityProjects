using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    GameSession gs;

    void Awake()
    {
        gs = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(collision.tag);
        if (collision.tag.Equals("Player")) {
            Destroy(gameObject);
            gs.pickupCoin();
        }
    }
}
