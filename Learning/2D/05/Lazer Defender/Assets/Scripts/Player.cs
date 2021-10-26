using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movment")]
    [SerializeField] float movmentSpeed = 5f;

    [Header("Camera")]
    [SerializeField] float paddingTop = 0f;
    [SerializeField] float paddingBottom = 0f;
    [SerializeField] float paddingLeft = 0f;
    [SerializeField] float paddingRight = 0f;

    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;

    Shooter shooter;

    private void Awake() {
        InitBounds();
        shooter = GetComponent<Shooter>();
    }

    void OnMove(InputValue value) {
        rawInput = value.Get<Vector2>();
    }

    void InitBounds() {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer() {
        // transform.position += new Vector3(rawInput.x * movmentSpeed * Time.deltaTime, rawInput.y * movmentSpeed * Time.deltaTime, 0f);
        //transform.position += (Vector3) rawInput * movmentSpeed * Time.deltaTime;
        Vector2 delta = rawInput * movmentSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;
    }

    void OnFire(InputValue value) {
        if (shooter != null) {
            shooter.isFiring = value.isPressed;
        }
    }
}
