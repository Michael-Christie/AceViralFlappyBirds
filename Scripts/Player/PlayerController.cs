using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    InGameGameMode gameMode;
    Animation anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
        anim.Play("MegaRampFly");

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
                if(Input.touchCount > 0)
                {
                    Touch t = Input.touches[0];
                    if (t.phase != TouchPhase.Began)
                        return;
                }
                //adds force
                AddUpwardsForce(3);
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
