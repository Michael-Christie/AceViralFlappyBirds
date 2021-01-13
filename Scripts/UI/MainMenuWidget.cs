using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuWidget : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField]
    GameObject MainMenu;
    [SerializeField]
    GameObject HatMenu;

    //private variables for the main menu
    [Header("Menu Widgets")]
    [SerializeField]
    Button btnPlayGame;
    [SerializeField]
    Text txtHighScore;
    [SerializeField]
    Button btnHatMenu;

    [Header("Hat Widgets")]
    [SerializeField]
    Button btnToMenu;
    [SerializeField]
    HatWidget[] HatWidgets;

    //public high score scriptable object
    [Header("Highscore")]
    public PlayInfoObject PlayerInfo;

    private void Awake()
    {
        //adds the play game to the onclick delegate
        btnPlayGame.onClick.AddListener(PlayGame);
        btnHatMenu.onClick.AddListener(ShowHatMenu);
        btnToMenu.onClick.AddListener(ToMenu);
        //changes the high score text
        txtHighScore.text = "High Score:\n" + PlayerInfo.HighScore.ToString("000#") ;
    }

    //loads the game scene when the button is clicked
    void PlayGame()
    {

        SoundManager.GetSoundManager()?.PlayButtonPressed();

        SceneManager.LoadScene(1);
    }

    void ShowHatMenu()
    {
        //show the hat menu
        MainMenu.SetActive(false);
        HatMenu.SetActive(true);
        //updat the hat menu content
        UpdateHatMenu();
    }

    void ToMenu()
    {
        //show the main menu
        MainMenu.SetActive(true);
        HatMenu.SetActive(false);
    }

    public void SelectNewHat(GameObject hat)
    {
        //set the new hat in the player info SO
        PlayerInfo.PlayerHat = hat;
        //updat hat menu contents
        UpdateHatMenu();
    }

    void UpdateHatMenu()
    {
        //for each hat, update its content
        foreach(HatWidget h in HatWidgets)
        {
            h.UpdateHat(h.Hat == PlayerInfo.PlayerHat, PlayerInfo.HighScore);
        }
    }
}
