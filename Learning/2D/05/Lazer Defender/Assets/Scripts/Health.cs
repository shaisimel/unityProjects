using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] int pointsValue = 0;
    ScoreKeeper scoreKeeper;
    UIDisplay ui;
    int maxHealth;

    CameraShake cameraShake;
    [SerializeField] bool applyCameraShakeOnHit;
    AudioPlayer audioPlayer;

    private void Awake() {
        maxHealth = health;
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        ui = FindObjectOfType<UIDisplay>();
        UpdateUi();
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

    private void UpdateUi() {
        if (isPlayer) {
            ui.updateHealthBar(Mathf.Max(0f, (float)health / maxHealth));
        }
        
    }

    private void TakeDamage(int damageTaken) {
        audioPlayer.PlayTakingDamageClip(); 
        health -= damageTaken;
        UpdateUi();        

        if (health <= 0) {
            if (!isPlayer) {
                scoreKeeper.addToScore(pointsValue);
            } else {
                FindObjectOfType<LevelManager>().LoadGameOverScreen();
            }
            Destroy(gameObject);
        }
    }

    public int getCurrentHealth() {
        return health;
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
