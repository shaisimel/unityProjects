using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float driverSpeed = 0.01f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float carRotation = 0.1f;
    [SerializeField] float accelriationTime = 2f;
    private float accelerationSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        if(verticalAxis != 0f){
            accelerationSpeed += Time.deltaTime * Mathf.Abs(verticalAxis);
            accelerationSpeed = Mathf.Min(accelerationSpeed, 1.0f);
        } else {
            accelerationSpeed = 0;
        }
        float steerAmount = Input.GetAxis("Horizontal") * carRotation * Time.deltaTime * Input.GetAxis("Vertical");
        float driveAmount = Input.GetAxis("Vertical") * driverSpeed * Time.deltaTime * accelerationSpeed;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0, driveAmount, 0);
    }
/*
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag.Equals("boost")){
            driverSpeed = boostSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        driverSpeed = slowSpeed;
    }*/
}
