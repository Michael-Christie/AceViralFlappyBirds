using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    //If the player hits one of the triggers, then they fell out of the world
    private void OnTriggerEnter(Collider other)
    {
        //Get the GameMode & call fall out world
        InGameGameMode.GetGameMode()?.PlayerFellOutWorld();

        SoundManager.GetSoundManager()?.PlayFallOutWorld();

    }
}
