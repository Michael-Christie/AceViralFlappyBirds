using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    InGameGameMode gameMode;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        DisableCharacter();
    }

    private void Start()
    {
        gameMode = InGameGameMode.GetGameMode();
    }

    private void Update()
    {
        if (gameMode.IsGameRunning())
        {
            //if the user touches the screen
            if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
            {
                //adds force
                if (Application.isEditor)
                    AddUpwardsForce(3);
                else
                    AddUpwardsForce(.75f);
            }
        }
    }

    //Adds an upwards force to the player
    void AddUpwardsForce(float amount)
    {
        rb.AddForce(Vector3.up * amount, ForceMode.Impulse);
    }

    //disables the gravity of the character
    public void DisableCharacter()
    {
        rb.useGravity = false;
    }
    //enables the gravity of the character
    public void EnableCharacter()
    {
        rb.useGravity = true;
    }

}
