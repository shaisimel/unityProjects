using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    GameSession gs;
    [SerializeField] AudioClip clip;

    void Awake()
    {
        gs = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //Debug.Log(collision.tag);
        if (collision.tag.Equals("Player")) {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
            gs.pickupCoin();
            Destroy(gameObject);
        }
    }
}
