using UnityEngine;

public class CameraBob : MonoBehaviour
{
    public float bobSpeed = 5f;  // Speed of the bobbing
    public float bobAmount = 0.1f;  // Height of the bobbing
    public float bobFrequency = 1.5f;  // Frequency of the bobbing

    private Vector3 startPosition;  // Original position of the camera
    private float timer = 0f;  // Keeps track of time

    private void Start()
    {
        // Save the initial position of the camera
        startPosition = transform.localPosition;
    }

    private void Update()
    {
        // Check if the player is moving
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            // Calculate the bobbing effect
            timer += Time.deltaTime * bobSpeed;
            float bobOffset = Mathf.Sin(timer * bobFrequency) * bobAmount;

            // Apply the bobbing effect to the camera's position
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(startPosition.x, startPosition.y + bobOffset, startPosition.z), 5*Time.deltaTime);
        }
        else
        {
            // If the player stops moving, reset the position to avoid the camera floating
            timer = 0f;
            transform.localPosition = startPosition;
        }
    }
}
