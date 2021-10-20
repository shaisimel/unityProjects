using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabtSpawner : MonoBehaviour
{
    [SerializeField] GameObject baby;
    [SerializeField] float spwanDelay = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawn() {
        int i = 0;
        while (true) {
            Debug.Log(i);
            Instantiate(baby, gameObject.transform);
            yield return new WaitForSecondsRealtime(spwanDelay);
            i++;
        }
    }
}
