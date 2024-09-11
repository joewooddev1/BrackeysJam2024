using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform ladderTop;

    public void LadderTop() 
    {
        StartCoroutine(TeleportPlayer());
    }

    IEnumerator TeleportPlayer() 
    {
        CharacterState.Instance.DisableCharacter();
        yield return new WaitForSeconds(0.1f);
        player.position = ladderTop.position;
        yield return new WaitForSeconds(0.1f);
        CharacterState.Instance.EnableCharacter();
    }
}
