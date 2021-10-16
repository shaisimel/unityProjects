using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PipesSpawnPoint;
    [SerializeField] GameObject ObjectToSpawn;
    [SerializeField] float spawnDelay = 2f;
    [SerializeField] float topHeight = 4f;
    [SerializeField] float bottomHeight = -4f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI deathText;
    int score = 0;
    float HeightRange;

    // Start is called before the first frame update
    void Start()
    {
        HeightRange = topHeight - bottomHeight;
        StartCoroutine(SpawnGates());
        deathText.enabled = false;
        updateScore();
    }

    void updateScore() {
        scoreText.text = "Score: " + score;
    }

    public void Die() {
       // EditorApplication.isPaused = true;
        deathText.enabled = true;
    }

    public void IncreasScore() {
        score++;
        updateScore();
    }

    private IEnumerator SpawnGates() {
        while (true) {
            GameObject gate = Instantiate(ObjectToSpawn, PipesSpawnPoint.transform);
            gate.transform.position = new Vector2(gate.transform.position.x, generateRandomHeight());
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private float generateRandomHeight() {
        return topHeight - (HeightRange* Random.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
