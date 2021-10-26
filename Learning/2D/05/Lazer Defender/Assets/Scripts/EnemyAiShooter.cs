using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiShooter : MonoBehaviour
{
    Shooter shooter;

    private void Awake() {
        shooter = GetComponentInParent<Shooter>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Player")) {
            shooter.isFiring = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag.Equals("Player")) {
            shooter.isFiring = false;
        }
    }
}
