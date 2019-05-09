using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    public static IEnumerator Movement(BoardPiece boardPiece, Vector3 target, float duration)
    {
        // This is a method to move the character over time to a target position at a
        // speed set by the 'duration' parameter.

        if(boardPiece.IsMoving) yield break;

        boardPiece.IsMoving = true;
        float counter = 0;

        while(counter < duration)
        {
            counter += Time.deltaTime;
            boardPiece.transform.position = Vector3.Lerp(boardPiece.transform.position, target, counter / duration);
            yield return null;
        }

        boardPiece.IsMoving = false;
    }
}
