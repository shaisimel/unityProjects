using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;

    private void OnTriggerEnter2D(Collider2D collision) {
        DamageDealer dd = collision.GetComponent<DamageDealer>();
        if (dd != null) {
            TakeDamage(dd.getDamage());
            dd.hit();
        }
    }

    private void TakeDamage(int damageTaken) {
        health -= damageTaken;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
