using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Player")) {
            finishEffect.Play();
            Invoke("LoadScene", loadDelay);
        }
    }

    private void LoadScene() {
        //Debug.Log("You Win!");
        SceneManager.LoadScene(0);
    }
}
