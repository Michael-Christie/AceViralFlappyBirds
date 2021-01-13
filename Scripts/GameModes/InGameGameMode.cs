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
    private void Start()
    {
        //add the hat to the player
        //if no player set, find one
        if (!Player)
            Player = FindObjectOfType<PlayerController>();
        //add the hat
        Player.AddHat(HighScore.PlayerHat);
    }

    bool bGameRunning = false;
    //public getter for if the game is running
    public bool IsGameRunning() { return bGameRunning; }

    public void StartGame()
    {
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
    public PlayInfoObject HighScore;
    public ParticleSystem beatHighScore;

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
        //set the game as not running
        bGameRunning = false;

        //if the players high score is lower then their current score, set the new high score
        if (HighScore.HighScore < distancedTraveled)
            HighScore.HighScore = (int)distancedTraveled;

        //Show UI to show Game Over;
        GameHud Hud = GameHud.GetInstance();
        Hud.ShowGameOver(Reason, (int)distancedTraveled, HighScore.HighScore);

    }
    #endregion

    #region Distance Stuff
    //delegates for when total distance is updated
    public delegate void FOnDistanceUpdate(float distance);
    public FOnDistanceUpdate OnDistanceUpdate;
    //the animator to pop the distance text
    [Header("UI")]
    public Animator DistanceUIAnimator;
    //private bool to run the pop text once per game.
    bool bHasBeatenRecord;
    //current distance travelled.
    float distancedTraveled = 0;
    //Setter for distance travelled
    public void AddDistanceTraveled(float value)
    {
        //checks its a possitive value
        if (value > 0)
        {
            distancedTraveled += value;

            if(!bHasBeatenRecord && distancedTraveled > HighScore.HighScore)
            {
                //you beat your record woo!
                beatHighScore.Play();
                bHasBeatenRecord = true;
                DistanceUIAnimator.SetTrigger("PopText");
            }
            //Update some UI.
            OnDistanceUpdate?.Invoke(distancedTraveled);
        }
    }
    #endregion
}
