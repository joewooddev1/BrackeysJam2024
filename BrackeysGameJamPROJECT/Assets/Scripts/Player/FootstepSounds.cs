using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSounds : MonoBehaviour
{
    // Reference to the player's character controller or Rigidbody
    private CharacterController controller;

    // Array of footstep sounds for different surfaces
    public AudioClip[] footstepSounds;

    // AudioSource to play footstep sounds
    private AudioSource audioSource;

    // Movement speed threshold to trigger footstep sounds
    public float stepInterval = 0.5f; // Time interval between steps
    private float stepTimer;

    // Volume control for the footstep sounds
    public float footstepVolume = 0.5f;

    // Layer mask to detect the ground (can be used for different surface types)
    public LayerMask groundMask;

    // Ground material/surface check (optional)
    public string groundTag;

    void Start()
    {
        // Get the CharacterController component
        controller = GetComponent<CharacterController>();

        // Get the AudioSource component (attached to the player)
        audioSource = GetComponent<AudioSource>();

        // Initialize the step timer
        stepTimer = stepInterval;
    }

    void Update()
    {
        // Check if the player is grounded and moving
        if (controller.isGrounded && controller.velocity.magnitude > 0.1f)
        {
            // Decrease the step timer by the time since last frame
            stepTimer -= Time.deltaTime;

            // If timer reaches 0, play a footstep sound
            if (stepTimer <= 0)
            {
                PlayFootstepSound();
                stepTimer = stepInterval; // Reset the timer
            }
        }
    }

    // Play a random footstep sound from the array
    void PlayFootstepSound()
    {
        // Check if there's a ground surface (optional, based on ground detection)
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1.1f, groundMask))
        {
            if (hit.collider.CompareTag(groundTag)) // Optional ground tag check
            {
                // Play footstep sound for specific surface
            }
        }

        // Choose a random footstep sound
        int index = Random.Range(0, footstepSounds.Length);
        audioSource.PlayOneShot(footstepSounds[index], footstepVolume);
    }
}
