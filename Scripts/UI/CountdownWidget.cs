using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownWidget : MonoBehaviour
{
    [SerializeField]
    Text txtCountDown;

    [SerializeField]
    Animator animator;

    private void Start()
    {
        StartCoroutine("CountDown");
    }

    //The animation for fading text in and out
    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1.0f);
        txtCountDown.text = "3";
        animator.SetTrigger("PulseText");
        yield return new WaitForSeconds(0.5f);
        SoundManager.GetSoundManager()?.PlayCountDownBeep();
        yield return new WaitForSeconds(0.5f);
        txtCountDown.text = "2";
        animator.SetTrigger("PulseText");
        yield return new WaitForSeconds(0.5f);
        SoundManager.GetSoundManager()?.PlayCountDownBeep();
        yield return new WaitForSeconds(0.5f);
        txtCountDown.text = "1";
        animator.SetTrigger("PulseText");
        yield return new WaitForSeconds(0.5f);
        SoundManager.GetSoundManager()?.PlayCountDownBeep();
        yield return new WaitForSeconds(0.5f);
        txtCountDown.text = "GO!";
        animator.SetTrigger("PulseText");
        yield return new WaitForSeconds(0.5f);
        SoundManager.GetSoundManager()?.PlayGameStartSound();
        InGameGameMode.GetGameMode().StartGame();
        yield return new WaitForSeconds(1f);
        //hid the go, destroy the UI;
        Destroy(gameObject);
    }
}
