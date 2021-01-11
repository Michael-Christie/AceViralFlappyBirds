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
        StartCountDown();
    }

    void StartCountDown()
    {
        StartCoroutine("CountDown");
    }

    IEnumerator CountDown()
    {
        txtCountDown.text = "3";
        animator.SetTrigger("PulseText");
        yield return new WaitForSeconds(1.0f);
        txtCountDown.text = "2";
        animator.SetTrigger("PulseText");
        yield return new WaitForSeconds(1.0f);
        txtCountDown.text = "1";
        animator.SetTrigger("PulseText");
        yield return new WaitForSeconds(1.0f);
        txtCountDown.text = "GO!";
        animator.SetTrigger("PulseText");
        yield return new WaitForSeconds(1.0f);
        //hid the go, destroy the UI;
        Destroy(gameObject);
    }
}
