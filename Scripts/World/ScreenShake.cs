using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    float ShakeDuration = 0.0f;
    Vector3 startingLocation;

    private void Awake()
    {
        startingLocation = transform.localPosition;
    }

    // Update is called once per frame
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

    public void SetShakerTime(float duration)
    {
        ShakeDuration = duration;
    }
}
