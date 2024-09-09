using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollisionSounds : MonoBehaviour
{
    [SerializeField] private float minimumCollisionSpeed;

    [Header("SFX")]
    [SerializeField] private AudioClip collisionSound;

    private AudioSource source;

    private void Start()
    {
        TryGetComponent(out source);
    }

    private void OnCollisionEnter(Collision collision)
    {
        float volume = Mathf.Clamp01(collision.relativeVelocity.magnitude);
        source.PlayOneShot(collisionSound, volume);
    }
}
