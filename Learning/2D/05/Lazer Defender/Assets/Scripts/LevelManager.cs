using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float loadSceneDelay = 2f;
    ScoreKeeper scoreKeeper;

    private void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGame() {
        if(scoreKeeper!=null) scoreKeeper.Reset();
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGameOverScreen() {
        StartCoroutine(LoadSceneWithDelay("Game Over", loadSceneDelay));
    }

    public void QuitGame() {
        Debug.Log("Game quitted");
        Application.Quit();
    }

    IEnumerator LoadSceneWithDelay(string sceneName, float delay) {
        // Debug.Log("Loadded scene [" + sceneName + "] with delay " + delay);
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene(sceneName);
    }
}
