using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHud : MonoBehaviour
{
    private static GameHud instance;
    //public getter for the gamemode instance
    public static GameHud GetInstance() { return instance; }

    private void Awake()
    {
        //sets up the gamemode instance
        if (instance)
            Destroy(this);
        instance = this;
    }

    [Header("InGame UI"), SerializeField]
    Button btnPause;
    [SerializeField]
    Text txtDistance;
    [Header("Pause UI")]
    [SerializeField]
    GameObject PauseMenu;
    [SerializeField]
    Button btnRestart;
    [SerializeField]
    Button btnUnpause;
    [Header("Game Over")]
    [SerializeField]
    GameObject GameOverMenu;
    [SerializeField]
    GameOverWidget gameOverWidget;

    void Start()
    {
        //add on button click events
        btnPause.onClick.AddListener(PauseGame);
        btnUnpause.onClick.AddListener(UnPauseGame);
        btnRestart.onClick.AddListener(Restart);

        //assigning update distance text to the delegate in the game mode
        InGameGameMode GM = InGameGameMode.GetGameMode();
        GM.OnDistanceUpdate += DistanceUpdate;
        //hides and shows UI objects
        txtDistance.gameObject.SetActive(false);
        btnPause.gameObject.SetActive(false);
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
    }

    //Deals with showing UI after the count down has finished
    public void OnCountDownFinished()
    {
        //set UI elements to visable
        txtDistance.gameObject.SetActive(true);
        btnPause.gameObject.SetActive(true);
    }
    //updating text function
    void DistanceUpdate(float newDistance)
    {
        txtDistance.text = newDistance.ToString("#") + "m";
    }
    //pauses the game
    void PauseGame()
    {
        //Pause the game from the gamemode
        InGameGameMode.GetGameMode()?.PauseGame();
        //hides objects
        btnPause.gameObject.SetActive(false);
        //shows objects
        PauseMenu.SetActive(true);
        //plays the button sound is sound manager exists.
        SoundManager.GetSoundManager()?.PlayButtonPressed();
    }
    //unPauses the game
    void UnPauseGame()
    {
        //Unpauses the gamemode
        InGameGameMode.GetGameMode()?.UnPauseGame();
        //hides objects
        PauseMenu.SetActive(false);
        //shows objects
        btnPause.gameObject.SetActive(true);
        //plays the button sound is sound manager exists.
        SoundManager.GetSoundManager()?.PlayButtonPressed();
    }

    //Reloads the scene
    void Restart()
    {
        //plays the button sound is sound manager exists.
        SoundManager.GetSoundManager()?.PlayButtonPressed();
        //loads the game again.
        SceneManager.LoadScene(1);
    }

    public void ShowGameOver(string Reason, int score, int highScore)
    {
        //Hide UI layers
        btnPause.gameObject.SetActive(false);
        txtDistance.gameObject.SetActive(false);
        //set the game over state up
        gameOverWidget.SetUp(Reason, score, highScore);
        //show game over UI
        GameOverMenu.SetActive(true);
    }
}
