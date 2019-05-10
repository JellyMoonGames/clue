using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : Motor
{
    // Author - Daniel Kean

    public override Tile ProcessMovement()
    {
        Tile targetTile = null;

        if(Input.GetButtonDown("Up"))           targetTile = Character.CurrentTile.GetNeighbour("Up");
        else if(Input.GetButtonDown("Down"))    targetTile = Character.CurrentTile.GetNeighbour("Down");
        else if(Input.GetButtonDown("Left"))    targetTile = Character.CurrentTile.GetNeighbour("Left");
        else if(Input.GetButtonDown("Right"))   targetTile = Character.CurrentTile.GetNeighbour("Right");

        return targetTile;
    }
}
