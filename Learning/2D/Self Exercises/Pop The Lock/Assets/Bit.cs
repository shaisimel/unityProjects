using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bit : MonoBehaviour
{
    [SerializeField] GameObject circleToRotateAround;
    [SerializeField] float startingRotation = 120f;
    [SerializeField] float minStartingRotation = 45f;

    // Start is called before the first frame update
    void Start()
    {
        ResetBit();
    }

    public void ResetBit() {
        Rotate(Random.value * startingRotation, 1, minStartingRotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rotate(float rotateAmount, int rotateDirection, float minRotation) {
        transform.localScale = new Vector3 (rotateDirection, transform.localScale.y, transform.localScale.z);
        transform.RotateAround(circleToRotateAround.transform.position, Vector3.forward, rotateDirection * (minRotation + (Random.value *  rotateAmount)));
    }
}
