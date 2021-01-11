using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameGameMode : MonoBehaviour
{
    #region Game Instance
    private static InGameGameMode instance;
    //public getter for the gamemode instance
    public static InGameGameMode GetGameMode() { return instance; }

    private void Awake()
    {
        //sets up the gamemode instance
        if (instance)
            Destroy(this);
        instance = this;
    }
    #endregion

    //Tempoary start game
    private void Start()
    {
        //if no player set, find one
        if (!Player)
            Player = FindObjectOfType<PlayerController>();

        StartCoroutine(StartGame());
    }
    //Tempoary start game
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3.0f);
        bGameRunning = true;
        //enables the player
        Player.EnableCharacter();
    }

    #region Game Running
    bool bGameRunning = false;
    //public getter for if the game is running
    public bool IsGameRunning() { return bGameRunning; }

    [Header("Gameplay")]
    public PlayerController Player;

    public void PlayerHitSomething()
    {
        GameOver("Hit An Object!");
    }

    public void PlayerFellOutWorld()
    {
        GameOver("Fell Out Of The World!");
    }

    void GameOver(string Reason)
    {
        //Disable the player from moving
        Player.DisableCharacter();
        //set the game as not running
        bGameRunning = false;

        //Show UI to show Game Over;
    }
    #endregion

    #region Distance Stuff
    float distancedTraveled = 0;
    //Setter for distance travelled
    public void AddDistanceTraveled(float value)
    {
        //checks its a possitive value
        if (value > 0)
        {
            distancedTraveled += value;
            //Update some UI.

        }
    }
    #endregion
}
