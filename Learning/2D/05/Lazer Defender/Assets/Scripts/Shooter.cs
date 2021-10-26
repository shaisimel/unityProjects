using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float firingRate = 0.2f;
    [SerializeField] GameObject spawnPoint;

    public bool isFiring = false;
    Coroutine fireCorutine;

    // Start is called before the first frame update
    void Start()
    {
        
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
            GameObject instace = Instantiate(projectilePrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            Rigidbody2D rb2d = instace.GetComponent<Rigidbody2D>();
            if (rb2d != null) {
                rb2d.velocity = transform.up * projectileSpeed;
            }

            Destroy(instace, projectileLifeTime);
            yield return new WaitForSecondsRealtime(firingRate);
        }
    }
}
