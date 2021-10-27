using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float firingRate = 0.2f;
    [SerializeField] GameObject spawnPoint;
    
    [Header("AI")]
    [SerializeField] bool useAi = false;
    [SerializeField] float spawnVarriance = 0.5f;
    [SerializeField] float minimunFiringRate = 0.2f;

    [HideInInspector] public bool isFiring = false;
    Coroutine fireCorutine;
    AudioPlayer audioPlayer;

    private void Awake() {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (useAi) {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire() {
        if (isFiring && fireCorutine==null) {
            fireCorutine = StartCoroutine(FireContinusly());
        } else if (!isFiring && fireCorutine != null){
            StopCoroutine(fireCorutine);
            fireCorutine = null;
        }
        
    }

    IEnumerator FireContinusly() {
        while (true) {
            GameObject instace = Instantiate(projectilePrefab, 
                                             spawnPoint == null ? transform.position : spawnPoint.transform.position,
                                             spawnPoint == null ? transform.rotation : spawnPoint.transform.rotation);

            Rigidbody2D rb2d = instace.GetComponent<Rigidbody2D>();
            if (rb2d != null) {
                rb2d.velocity = transform.up * projectileSpeed;
            }

            Destroy(instace, projectileLifeTime);
            float waitTime = firingRate;
            if (useAi) {
                waitTime = Mathf.Clamp(Random.Range(firingRate - spawnVarriance, firingRate + spawnVarriance), minimunFiringRate, float.MaxValue);
            }

            audioPlayer.PlayShootingClip();
            yield return new WaitForSecondsRealtime(waitTime);
        }
    }
}
