using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPipes : MonoBehaviour
{
    //If the player hits one of the triggers, then they Hit Something
    private void OnTriggerEnter(Collider other)
    {
        //Get the GameMode & call hit  something
        InGameGameMode.GetGameMode()?.PlayerHitSomething();
        //Get the sound Manager and play the hit sound
        SoundManager.GetSoundManager()?.PlayPlayerHit();
        
    }
}
