using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    //public getter for the gamemode instance
    public static SoundManager GetSoundManager() { return instance; }

    private void Awake()
    {
        //sets up the gamemode instance
        if (instance)
            Destroy(this);
        instance = this;

        SFXsource = GetComponent<AudioSource>();

        DontDestroyOnLoad(this);
    }

    AudioSource SFXsource;

    [Header("Player Sounds"), SerializeField]
    AudioClip PlayerJumpSound;
    [SerializeField]
    AudioClip PlayerHitSomething;

    [Header("World"), SerializeField]
    AudioClip ClearedPipe;
    [SerializeField]
    AudioClip FallOutWorld;

    [Header("UI"), SerializeField]
    AudioClip ButtonConfrimPress;
    [SerializeField]
    AudioClip CountdownBeep;
    [SerializeField]
    AudioClip GameStartSound;

    //The player jumped sound effect.
    public void PlayPlayerJumped() { SFXsource.PlayOneShot(PlayerJumpSound); }
    //The player Hit something sound effect
    public void PlayPlayerHit() { SFXsource.PlayOneShot(PlayerHitSomething); }
    //The player Cleared the pipe
    public void PlayClearedPipe() { SFXsource.PlayOneShot(ClearedPipe); }
    //player fell out the world
    public void PlayFallOutWorld() { SFXsource.PlayOneShot(FallOutWorld); }

    //The player pressed a button
    public void PlayButtonPressed() { SFXsource.PlayOneShot(ButtonConfrimPress); }

    public void PlayCountDownBeep() { SFXsource.PlayOneShot(CountdownBeep); }

    public void PlayGameStartSound() { SFXsource.PlayOneShot(GameStartSound); }


}
