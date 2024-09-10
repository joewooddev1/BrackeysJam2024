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
                    box.OpenBoxWithKnife();

                    Destroy(gameObject);
                    Interactor.Instance.isHolding = false;
                }
            }
        }
    }
}
