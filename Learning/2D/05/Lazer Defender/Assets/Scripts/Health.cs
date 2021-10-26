using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag.Equals("Projectile") && !this.tag.Equals("Ai Trigger")) {
            DamageDealer dd = collision.GetComponent<DamageDealer>();
            if (dd != null) {
                TakeDamage(dd.getDamage());
                takeHitEffect();
                dd.hit();
            }
        }

        
    }

    private void TakeDamage(int damageTaken) {
        health -= damageTaken;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    private void takeHitEffect() {
        if (hitEffect != null) {
            ParticleSystem ps = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(ps, ps.main.duration + ps.main.startLifetime.constantMax);
        }
    }
}
