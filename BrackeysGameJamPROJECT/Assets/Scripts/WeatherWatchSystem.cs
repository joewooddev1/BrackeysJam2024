using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeatherWatchSystem : MonoBehaviour
{
    [SerializeField] private InputAction switchKnobLeft;
    [SerializeField] private InputAction switchKnobRight;
    [SerializeField] private InputAction twistKnob;

    [SerializeField] private Transform[] knobs;

    [SerializeField] private Camera fpCamera;
    [SerializeField] private Transform gameCameraLocation;

    public float switchKnobDirection;
    public float twistKnobDirection;

    public bool gameActive;

    public int currentKnob;
    private void Start()
    {
        switchKnobLeft.Enable();
        switchKnobRight.Enable();
        twistKnob.Enable();
    }

    public void ActivateGame() 
    {
        fpCamera.transform.position = gameCameraLocation.position;
        fpCamera.transform.rotation = gameCameraLocation.rotation;

        gameActive = true;
    }

    public void ExitGame()
    {
        fpCamera.transform.localPosition = new Vector3(0f, 1.8f, 0f);
        fpCamera.transform.localRotation = Quaternion.identity;

        gameActive = false;
    }

    private void Update()
    {
        if (gameActive)
        {
            CharacterState.Instance.DisableCharacter();

            MiniGameLoop();

            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                ExitGame();
                CharacterState.Instance.EnableCharacter();
            }
        }
    }

    private void MiniGameLoop()
    {
        if (switchKnobRight.WasPressedThisFrame()) 
        {
            SelectKnob(1);
        }
        else if(switchKnobLeft.WasPressedThisFrame()) 
        {
            SelectKnob(-1);
        }

        twistKnobDirection = twistKnob.ReadValue<Vector2>().x;
        TwistKnob(currentKnob, twistKnobDirection);
    }

    private void SelectKnob(float direction)
    {
        // Assuming direction is -1 or 1, depending on which way you want to move
        if (currentKnob >= 0 && currentKnob < knobs.Length)
        {
            currentKnob += (int)direction;

            // Clamp the currentKnob to stay within the bounds of the array
            currentKnob = Mathf.Clamp(currentKnob, 0, knobs.Length - 1);

            // Reset direction after change
            direction = 0;
        }


        for (int i = 0; i < knobs.Length; i++)
        {
            if (i == currentKnob)
            {
                knobs[i].localScale = new Vector3(1.2f, 1.2f, 1.2f);
            }
            else
            {
                knobs[i].localScale = Vector3.one;
            }
        }
    }

    private void TwistKnob(int knobIndex, float direction) 
    {
        knobs[knobIndex].transform.Rotate(0, direction, 0);
    }
}
