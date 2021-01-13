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
        MainMenu.SetActive(false);
        HatMenu.SetActive(true);
        UpdateHatMenu();
    }

    void ToMenu()
    {
        MainMenu.SetActive(true);
        HatMenu.SetActive(false);
    }

    public void SelectNewHat(GameObject hat)
    {
        PlayerInfo.PlayerHat = hat;
        UpdateHatMenu();
    }

    void UpdateHatMenu()
    {
        foreach(HatWidget h in HatWidgets)
        {
            Debug.Log(h.Hat + " " + PlayerInfo.PlayerHat);
            Debug.Log(h.Hat == PlayerInfo.PlayerHat);
            h.UpdateHat(h.Hat == PlayerInfo.PlayerHat, PlayerInfo.HighScore);
        }
    }
}
