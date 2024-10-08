using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float maxRayDistance = 3f;

    [Header("Input")]
    [SerializeField] private InputAction interactKey;

    [Header("Indication")]
    [SerializeField] private GameObject standardCrosshair;
    [SerializeField] private GameObject interactCrosshair;
    [SerializeField] private GameObject holdingCrosshair;

    [Header("UI")]
    [SerializeField] private TMPro.TMP_Text interactionText;

    [Header("Events")]
    public UnityEvent onPlayerInteracted;

    public Interaction currentInteraction;
    public Interaction lastInteraction;

    private Interaction interaction;

    public bool isHolding;

    [SerializeField] private LayerMask ignoreMask;
    private void Start()
    {
        interactKey.Enable();
    }

    public static Interactor Instance { get; private set; }

    public float hourOfDay;
    public int day;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        InteractionRay();
        Interact();
    }

    private void InteractionRay()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxRayDistance, ignoreMask))
        {
            if (hit.collider.attachedRigidbody.transform.TryGetComponent(out interaction))
            {
                interactionText.gameObject.SetActive(true);
                interactionText.text = "Left Mouse : " + interaction.interactionName;

                currentInteraction = interaction;
                if (!isHolding && currentInteraction.type == InteractionType.hold) { lastInteraction = interaction; }

                standardCrosshair.SetActive(false);
                interactCrosshair.SetActive(true);
            }
        }
        else 
        {
            currentInteraction = null;

            interactionText.gameObject.SetActive(false);

            standardCrosshair.SetActive(true);
            interactCrosshair.SetActive(false);

            Debug.Log("Stopped Looking");
        }
    }

    private void Interact() 
    {
        if (currentInteraction != null && currentInteraction.type == InteractionType.click)
        {
            if (interactKey.WasPressedThisFrame() && currentInteraction != null)
            {
                currentInteraction.onInteracted.Invoke();
                onPlayerInteracted.Invoke();

                standardCrosshair.SetActive(true);
                interactCrosshair.SetActive(false);
                currentInteraction = null;

                if (lastInteraction != null) { lastInteraction = null; }
            }
        }
        
        if (lastInteraction != null && lastInteraction.type == InteractionType.hold && lastInteraction.canGrab) 
        {
            if (interactKey.IsPressed() && currentInteraction != null)
            {
                lastInteraction.onInteracted.Invoke();
                onPlayerInteracted.Invoke();

                standardCrosshair.SetActive(false);
                interactCrosshair.SetActive(false);
                holdingCrosshair.SetActive(true);

                interactionText.gameObject.SetActive(false);

                isHolding = true;
            }
            else if(!interactKey.IsPressed() && lastInteraction != null)
            {
                isHolding = false;

                lastInteraction.onDropped.Invoke();

                standardCrosshair.SetActive(true);
                interactCrosshair.SetActive(false);
                holdingCrosshair.SetActive(false);

                currentInteraction = null;
            }
        }
    }
}
