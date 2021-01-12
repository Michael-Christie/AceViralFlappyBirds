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
        //resests time scale
        Time.timeScale = 1;

        //sets up the gamemode instance
        if (instance)
            Destroy(this);
        instance = this;
    }
    #endregion

    #region Game Running
    bool bGameRunning = false;
    //public getter for if the game is running
    public bool IsGameRunning() { return bGameRunning; }

    public void StartGame()
    {
        //if no player set, find one
        if (!Player)
            Player = FindObjectOfType<PlayerController>();

        bGameRunning = true;
        //enables the player
        Player.EnableCharacter();

        GameHud.GetInstance().OnCountDownFinished();
    }

    //Stops movement inside of the game
    public void PauseGame()
    {
        bGameRunning = false;
        Player.DisableCharacter();
        Time.timeScale = 0;
    }
    //Enables movement inside the game
    public void UnPauseGame()
    {
        bGameRunning = true;
        Player.EnableCharacter();
        Time.timeScale = 1;
    }

    [Header("Gameplay")]
    public PlayerController Player;
    public Highscore HighScore;

    //Reasons for the player to lose the game
    public void PlayerHitSomething()
    {
        GameOver("You Hit An Object!");
    }

    public void PlayerFellOutWorld()
    {
        GameOver("You Fell Out The World!");
    }
    //Shows game over to the player.
    void GameOver(string Reason)
    {
        //Disable the player from moving
        Player.DisableCharacter();
        //set the game as not running
        bGameRunning = false;
        Time.timeScale = 0;

        if (HighScore.HighScore < distancedTraveled)
            HighScore.HighScore = (int)distancedTraveled;

        //Show UI to show Game Over;
        GameHud Hud = GameHud.GetInstance();
        Hud.ShowGameOver(Reason, (int)distancedTraveled, HighScore.HighScore);

    }
    #endregion

    #region Distance Stuff
    public delegate void FOnDistanceUpdate(float distance);
    public FOnDistanceUpdate OnDistanceUpdate;

    [Header("UI")]
    public GameObject DistanceUI;

    float distancedTraveled = 0;
    //Setter for distance travelled
    public void AddDistanceTraveled(float value)
    {
        //checks its a possitive value
        if (value > 0)
        {
            distancedTraveled += value;
            //Update some UI.
            OnDistanceUpdate?.Invoke(distancedTraveled);
        }
    }
    #endregion
}
