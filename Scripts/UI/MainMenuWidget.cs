using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuWidget : MonoBehaviour
{
    [SerializeField]
    Button btnPlayGame;
    [SerializeField]
    Text txtHighScore;

    private void Awake()
    {
        //adds the play game to the onclick delegate
        btnPlayGame.onClick.AddListener(PlayGame);
        txtHighScore.text = "High Score:\n0000"; //change this to the new highscore
    }

    void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
