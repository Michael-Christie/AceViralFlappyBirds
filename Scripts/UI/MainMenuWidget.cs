using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuWidget : MonoBehaviour
{
    //private variables for the main menu
    [Header("Widgets")]
    [SerializeField]
    Button btnPlayGame;
    [SerializeField]
    Text txtHighScore;
    //public high score scriptable object
    [Header("Highscore")]
    public Highscore Highscore;

    private void Awake()
    {
        //adds the play game to the onclick delegate
        btnPlayGame.onClick.AddListener(PlayGame);
        //changes the high score text
        txtHighScore.text = "High Score:\n" + Highscore.HighScore.ToString("000#") ;
    }

    //loads the game scene when the button is clicked
    void PlayGame()
    {
        SoundManager.GetSoundManager()?.PlayButtonPressed();

        SceneManager.LoadScene(1);
    }
}
