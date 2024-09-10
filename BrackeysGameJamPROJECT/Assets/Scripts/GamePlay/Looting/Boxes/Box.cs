using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private GameObject openBoxModel;
    [SerializeField] private GameObject closedBoxModel;

    [SerializeField] private float collisionOpenSpeed;
    [SerializeField] private Animation knifeOpen;

    [SerializeField] private GameObject boxCutter;
    [SerializeField] private Transform boxCutterSpawnPoint;

    [SerializeField] AudioSource source;
    [SerializeField] AudioClip tapeRipSFX;

    public bool isOpen;
    private void Start()
    {
        TryGetComponent(out source);
    }

    private void OnCollisionEnter(Collision collision)
    {
        float collisionSpeed = collision.relativeVelocity.magnitude;

        if (collisionSpeed > collisionOpenSpeed) 
        {
            //OpenBox();
        }
    }

    public void OpenBox() 
    {
        if (isOpen) { return; }

        // particle
        // sound effect

        closedBoxModel.SetActive(false);
        openBoxModel.SetActive(true);

        isOpen = true;
    }

    public void OpenBoxWithKnife()
    {
        if (isOpen) { return; }
        
        // particle
        // sound effect

        knifeOpen.Play();

        StartCoroutine(ChangeBoxModel());
    }

    IEnumerator ChangeBoxModel() 
    {
        source.PlayOneShot(tapeRipSFX);

        yield return new WaitForSeconds(.6f);
        closedBoxModel.SetActive(false);
        openBoxModel.SetActive(true);

        Instantiate(boxCutter, boxCutterSpawnPoint.position, Quaternion.identity);

        isOpen = true;
    }
}
