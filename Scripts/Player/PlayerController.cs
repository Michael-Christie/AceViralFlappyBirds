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
        //Get components from the player object
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
        anim.Play("MegaRampFly");
        //stop the player from moving till the game is ready
        DisableCharacter();
    }

    private void Start()
    {
        //find the gamemode
        gameMode = InGameGameMode.GetGameMode();
    }

    private void Update()
    {
        //if the game is live
        if (gameMode.IsGameRunning())
        {
            //if the user touches the screen
            if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
            {
                //this is only here because I need the mouse down for testing in editor
                if(Input.touchCount > 0)
                {
                    //if the touch hasnt just been pressed, aka is a hold... return
                    Touch t = Input.touches[0];
                    if (t.phase != TouchPhase.Began)
                        return;
                }
                //adds force to the player
                AddUpwardsForce(3);

                SoundManager.GetSoundManager()?.PlayPlayerJumped();
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
