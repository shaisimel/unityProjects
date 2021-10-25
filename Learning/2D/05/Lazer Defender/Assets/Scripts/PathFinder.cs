using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpwaner enemySpwaner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int wayPointIndex = 0;

    private void Awake() {
        enemySpwaner = FindObjectOfType<EnemySpwaner>();
        waveConfig = enemySpwaner.getCurrentWave();
    }

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.getWaypoints();
        transform.position = waypoints[wayPointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    void FollowPath() {
        if(wayPointIndex < waypoints.Count) {
            Vector2 targetPosition = waypoints[wayPointIndex].position;
            float delta = waveConfig.GetMovmentSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position.Equals(targetPosition)) {
                wayPointIndex++;
            }
        } else {
            Destroy(gameObject);
        }
    }
}
