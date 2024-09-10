using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLateCollision : MonoBehaviour
{
    private Collider c;

    [SerializeField] private float timeTillCollsion;

    private void Start()
    {
        TryGetComponent(out c);

        StartCoroutine(SpawnWithoutCollider());
    }

    IEnumerator SpawnWithoutCollider() 
    {
        c.isTrigger = true;
        yield return new WaitForSeconds(timeTillCollsion);
        c.isTrigger = false;
    }
}
