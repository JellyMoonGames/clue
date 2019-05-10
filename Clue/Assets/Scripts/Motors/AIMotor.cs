using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMotor : Motor
{
    // Author - Daniel Kean

    private string[] directions = new string[4] { "Up", "Down", "Left", "Right" };
    private int randomNumberofMoves = 0;

    private new void Awake()
    {
        base.Awake();
    }

    public override Tile ProcessMovement()
    {
        Tile randomTile = Character.CurrentTile.GetNeighbour(GetRandomDirection());
        while(randomTile == null) randomTile = Character.CurrentTile.GetNeighbour(GetRandomDirection());

        while(randomTile == Character.CurrentTile || randomTile == randomTile.IsOccupied)
        {
            randomTile = Character.CurrentTile.GetNeighbour(GetRandomDirection());
        }

        return randomTile;
    }

    private string GetRandomDirection()
    {
        return directions[Random.Range(0, directions.Length)];
    }
}

