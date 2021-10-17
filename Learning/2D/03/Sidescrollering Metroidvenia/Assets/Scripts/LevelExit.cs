using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float waitTime;
    [SerializeField] string level;

    IEnumerator loadLevel() {
        yield return new WaitForSecondsRealtime(waitTime);
        SceneManager.LoadScene(level);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag.Equals("Player")) StartCoroutine(loadLevel());        
    }
}
