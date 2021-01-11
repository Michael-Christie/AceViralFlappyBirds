using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //if the user touches the screen
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            //adds force
            if (Application.isEditor)
                AddUpwardsForce(3.0f);
            else
                AddUpwardsForce(.75f);
        }
    }

    void AddUpwardsForce(float amount)
    {
        rb.AddForce(Vector3.up * amount, ForceMode.Impulse);
    }
}
