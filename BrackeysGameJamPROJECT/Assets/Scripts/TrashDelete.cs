using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrashDelete : MonoBehaviour
{
    [SerializeField] private UnityEvent onDestroyTrash;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Walkie Talkie") { Destroy(other.gameObject); } else { other.transform.position = CharacterState.Instance.transform.position; }
        onDestroyTrash.Invoke();
    }
}
