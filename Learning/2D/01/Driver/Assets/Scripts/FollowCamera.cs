using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float cameraDistance = 10;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0,0,cameraDistance);
    }
}
