using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInteraction : Interaction
{
    Room room;

    private void Awake()
    {
        room = GetComponent<Room>();
    }

    public override void PrimaryButton()
    {
        GuessManager.CurrentGuessState = GuessState.Room;

        if(GuessManager.CurrentGuessState != GuessState.Room) return;

        Debug.Log(room);
    }

    public override void SecondaryButton()
    {

    }
}
