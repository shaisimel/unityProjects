using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    [SerializeField] GameObject circleToRotateAround;
    [SerializeField] float rotationAngle = 1f;
    [SerializeField] int startDirection = 1;
    [SerializeField] float bitRotationStep = 90f;
    [SerializeField] float minBitRotationStep = 30f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Image failShade;


    Bit bit;
    bool isInBit = false;
    int score = 0;
    int direction;

    Vector3 startPosition;
    Quaternion startRotation;
    Vector3 startScale;
    bool isAlive = true;

    private void Awake() {
        startPosition = transform.position;
        startRotation = transform.rotation;
        startScale = transform.localScale;
        bit = FindObjectOfType<Bit>();
    }

    void resetGame() {
        failShade.enabled = false;
        score = 0;
        UpdateScoreText();
        direction = startDirection;
        transform.position = startPosition;
        transform.rotation = startRotation;
        transform.localScale = startScale;
        isAlive = true;
        bit.ResetBit();
    }

    // Start is called before the first frame update
    void Start()
    {
        resetGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) return;

        transform.RotateAround(circleToRotateAround.transform.position, Vector3.forward , direction * rotationAngle * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //Debug.Log("entered");
        if (collision.tag.Equals("Bit")) {
            isInBit = true;
        } else if (collision.tag.Equals("Fail")) {
            isAlive = false;
            failShade.enabled = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision) {
        //Debug.Log("exited");
        if (collision.tag.Equals("Bit")) {
            isInBit = false;
        }
    }

    private void OnClick(InputValue input) {
        if (!isAlive) {
            resetGame();
        } else if (isInBit) {
            score++;
            UpdateScoreText();
            direction *= -1;
            bit.Rotate(bitRotationStep, direction, minBitRotationStep);
            //Debug.Log("hit");
        } else {
            isAlive = false;
            failShade.enabled = true;
            //Debug.Log("miss");
        }
    }

    private void UpdateScoreText() {
        scoreText.text = score.ToString();
    }
}
