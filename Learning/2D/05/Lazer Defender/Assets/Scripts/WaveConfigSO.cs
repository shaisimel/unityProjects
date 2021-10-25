using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Transform pathPrefeb;
    [SerializeField] float movmentSpeed = 5f;
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] float timeBetweenEnemySpwans = 1f;
    [SerializeField] float spwanTimerVeriance = 0f;
    [SerializeField] float minimumSpwanTime = 0.2f;

    public Transform getStartingWayPoint() {
        return pathPrefeb.GetChild(0);
    }

    public List<Transform> getWaypoints() {
        List<Transform> result = new List<Transform>();
        foreach(Transform child in pathPrefeb) {
            result.Add(child);
        }
        
        return result;
    }

    public float GetMovmentSpeed() {
        return movmentSpeed;
    }

    public int GetEnemyCount() {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index) {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime() {
        return Mathf.Clamp(Random.Range(timeBetweenEnemySpwans - spwanTimerVeriance, timeBetweenEnemySpwans + spwanTimerVeriance),
                            minimumSpwanTime, float.MaxValue);
    }
}
