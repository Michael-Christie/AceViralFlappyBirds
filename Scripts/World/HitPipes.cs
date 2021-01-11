using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPipes : MonoBehaviour
{
    //If the player hits one of the triggers, then they Hit Something
    private void OnTriggerEnter(Collider other)
    {
        //Get the GameMode
        InGameGameMode GM = InGameGameMode.GetGameMode();
        //Call the player Hit something
        GM.PlayerHitSomething();
    }
}
