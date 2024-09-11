using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WeatherWatchSystem : MonoBehaviour
{
    [SerializeField] private InputAction switchKnobLeft;
    [SerializeField] private InputAction switchKnobRight;
    [SerializeField] private InputAction twistKnob;

    [SerializeField] private Transform[] knobs;

    [SerializeField] private Camera fpCamera;
    [SerializeField] private Transform gameCameraLocation;

    [SerializeField] private Image targetTemperature;
    [SerializeField] private Image currentTemperature;

    [SerializeField] private float pressureBuildup;

    public float switchKnobDirection;
    public float twistKnobDirection;

    public bool gameActive;

    public int currentKnob;

    public float amountHot;
    public float amountCold;

    private int timesUsed;
    [SerializeField] private UnityEvent onFirstExit;

    public bool canPressureBuildup;

    private void Start()
    {
        switchKnobLeft.Enable();
        switchKnobRight.Enable();
        twistKnob.Enable();
    }

    public void ActivateGame() 
    {
        fpCamera.transform.position = gameCameraLocation.position;

        gameActive = true;

        targetTemperature.rectTransform.localPosition = new Vector3(Random.Range(-500, 500), 0, 0);
    }

    public void ExitGame()
    {
        fpCamera.transform.localPosition = new Vector3(0f, 1.8f, 0f);
        fpCamera.transform.localRotation = Quaternion.identity;

        CharacterState.Instance.EnableCharacter();

        gameActive = false;

        if (timesUsed < 1) 
        {
            onFirstExit.Invoke();
        }

        timesUsed++;
    }

    private void Update()
    {
        pressureBuildup++;

        if (pressureBuildup > 500f && canPressureBuildup) 
        {
            PipeWall.Instance.SelectAndCrackRandomPipe();
            pressureBuildup = 0;
        }

        if (gameActive)
        {
            fpCamera.transform.rotation = gameCameraLocation.rotation;

            CharacterState.Instance.DisableCharacter();

            MiniGameLoop();

            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                ExitGame();

            }

            if (Vector3.Distance(targetTemperature.rectTransform.localPosition, currentTemperature.rectTransform.localPosition) < .1f) 
            {
                ExitGame();
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

        if (knobIndex == 0) 
        {
            amountHot += direction * 1f;
            amountHot = Mathf.Clamp(amountHot, -500f, 0f);
        }

        if (knobIndex == 1)
        {
            amountCold -= direction * 1f;
            amountCold = Mathf.Clamp(amountCold, 0f, 500f);
        }

        float finalRotation = amountHot + amountCold;
        currentTemperature.rectTransform.localPosition = new Vector3(Mathf.Clamp(finalRotation, -500f, 500f), 0, 0);
    }
}
