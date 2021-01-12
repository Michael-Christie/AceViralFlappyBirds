using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverWidget : MonoBehaviour
{
    [SerializeField]
    Text txtReason;
    [SerializeField]
    Text txtScores;
    [SerializeField]
    Button btnToMenu;

    private void Start()
    {
        btnToMenu.onClick.AddListener(ToMenu);
    }

    public void SetUp(string Reason, int Score, int HighScore)
    {
        txtReason.text = Reason;
        txtScores.text = "Score:\n\n"+ Score.ToString("000#") + "\n-----------------\nHighScore:\n\n" + HighScore.ToString("000#");
    }

    void ToMenu()
    {
        SoundManager.GetSoundManager()?.PlayButtonPressed();
        
        SceneManager.LoadScene(0);
    }
}
