using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwaner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    WaveConfigSO currentWave;
    [SerializeField] bool isLooping = true;


    private void Start() {
        StartCoroutine(SpwanEnemyWaves());
    }

    public WaveConfigSO getCurrentWave() {
        return currentWave;
    }

    IEnumerator SpwanEnemyWaves() {
        do {
            foreach (WaveConfigSO wave in waveConfigs) {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++) {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.getStartingWayPoint().position, Quaternion.Euler(0,0,180), transform);
                    yield return new WaitForSecondsRealtime(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSecondsRealtime(timeBetweenWaves);
            }
        }
        while (isLooping);
    }
}
