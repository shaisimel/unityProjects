using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range (0f, 1f)] float shootingVolume = 1f;

    [Header("Taking Damage")]
    [SerializeField] AudioClip takingDamageClip;
    [SerializeField] [Range(0f, 1f)] float takingDamageVolume = 1f;

    public void PlayShootingClip() {
        if (shootingClip != null) {
            AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
        }
    }

    public void PlayTakingDamageClip() {
        if (takingDamageClip != null) {
            AudioSource.PlayClipAtPoint(takingDamageClip, Camera.main.transform.position, takingDamageVolume);
        }
    }
}
