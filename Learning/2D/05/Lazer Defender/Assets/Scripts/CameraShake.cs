using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeTime = 1f;
    [SerializeField] float shakeMegnatuitde = 0.5f;
    Vector3 initalPosition;

    // Start is called before the first frame update
    void Start()
    {
        initalPosition = transform.position;
    }


    public void Play() {
        StartCoroutine(Shake());
    }

    IEnumerator Shake() {
        float totalTime = 0f;
        while (totalTime < shakeTime) {
            transform.position = initalPosition + (Vector3) Random.insideUnitCircle * shakeMegnatuitde;
            yield return new WaitForEndOfFrame();
            totalTime += Time.deltaTime;
        }
        transform.position = initalPosition;
    }
}
