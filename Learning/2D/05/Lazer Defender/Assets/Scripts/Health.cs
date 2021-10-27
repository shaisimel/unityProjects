using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;

    CameraShake cameraShake;
    [SerializeField] bool applyCameraShakeOnHit;
    AudioPlayer audioPlayer;

    private void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

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
        audioPlayer.PlayTakingDamageClip(); 
        health -= damageTaken;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    private void takeHitEffect() {
        if (cameraShake!=null && applyCameraShakeOnHit) {
            cameraShake.Play();
        }

        if (hitEffect != null) {
            ParticleSystem ps = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(ps, ps.main.duration + ps.main.startLifetime.constantMax);
        }
    }
}
