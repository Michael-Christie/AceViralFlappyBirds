using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    //If the player hits one of the triggers, then they fell out of the world
    private void OnTriggerEnter(Collider other)
    {
        //if the thing that entered the trigger the player
        if (!other.gameObject.GetComponent<PlayerController>()) return;

        //if the game is running
        if (InGameGameMode.GetGameMode().IsGameRunning())
        {
            //Get the GameMode & call fall out world
            InGameGameMode.GetGameMode()?.PlayerFellOutWorld();
            //play the fell out of world sound effect.
            SoundManager.GetSoundManager()?.PlayFallOutWorld();
        }

    }
}
