using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxKnife : MonoBehaviour
{
    [SerializeField] private float collisionSpeedKnife;

    private void OnCollisionEnter(Collision collision)
    {
        float collisionSpeed = collision.relativeVelocity.magnitude;

        if (collisionSpeed > collisionSpeedKnife)
        {
            if (collision.gameObject.TryGetComponent(out Box box)) 
            {
                if (!box.isOpen) 
                {
                    Interactor.Instance.isHolding = false;
                    Interactor.Instance.currentInteraction = null;
                    Interactor.Instance.lastInteraction = null;
                    box.OpenBoxWithKnife();

                    Destroy(gameObject);
                }
            }
        }
    }
}
