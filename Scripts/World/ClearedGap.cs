using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearedGap : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        PlayerController PC = other.gameObject.GetComponent<PlayerController>();
        if (!PC) return;

        WorldGen.GetWorld()?.PlayParticles(PC.transform.position);

        SoundManager.GetSoundManager()?.PlayClearedPipe();
    }
}
