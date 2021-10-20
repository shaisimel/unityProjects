using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashEffect;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Ground")) {
            crashEffect.Play();
            Invoke("LoadScene", 1f);
        }
    }

    private void LoadScene() {
        // Debug.Log("You Lose!");
        SceneManager.LoadScene(0);
    }
}
