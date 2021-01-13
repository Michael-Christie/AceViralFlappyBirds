using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    float ShakeDuration = 0.0f;
    Vector3 startingLocation;

    private void Awake()
    {
        //set the default starting location, aka 0 0 -10
        startingLocation = transform.localPosition;
    }

    void Update()
    {
        //if there is shaking to do
        if(ShakeDuration > 0)
        {
            //remove the time left
            ShakeDuration -= Time.deltaTime;

            //if shake is less then 0, set the cam location back to the center.
            if(ShakeDuration <= 0)
            {
                transform.localPosition = startingLocation;
                ShakeDuration = 0;
            }
            else
            {
                transform.localPosition = startingLocation + Random.insideUnitSphere * .25f;
            }
        }
    }

    //public method to start camera shake off
    public void SetShakerTime(float duration)
    {
        ShakeDuration = duration;
    }
}
