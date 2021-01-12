using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearedGap : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //see if what hit you was the player collider
        PlayerController PC = other.gameObject.GetComponent<PlayerController>();
        if (!PC) return;

        //get the game mode
        if (InGameGameMode.GetGameMode().IsGameRunning())
        {
            //spawn the particles in the world
            WorldGen.GetWorld()?.PlayParticles(PC.transform.position);
            //play the cleared pipe sound effect.
            SoundManager.GetSoundManager()?.PlayClearedPipe();
        }
    }
}
