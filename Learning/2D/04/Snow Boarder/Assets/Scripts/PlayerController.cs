using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    SurfaceEffector2D se2d;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        se2d = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update() {
        RotatePlayer();
        RespondToBoost();
    }

    private void RespondToBoost() {
        if (Input.GetKey(KeyCode.W)) {
            se2d.speed = boostSpeed;
        } else {
            se2d.speed = baseSpeed;
        }
    }

    private void RotatePlayer() {
        if (Input.GetKey(KeyCode.A)) {
            rb.AddTorque(torqueAmount);
        } else if (Input.GetKey(KeyCode.D)) {
            rb.AddTorque(-torqueAmount);
        }
    }
}
 