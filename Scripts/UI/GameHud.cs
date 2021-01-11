using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    [Header("In Game UI"), SerializeField]
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

    void Start()
    {
        //add on button click events
        btnPause.onClick.AddListener(PauseGame);
        btnUnpause.onClick.AddListener(UnPauseGame);

        //assing update distance text to the delegate in the game mode
        InGameGameMode GM = InGameGameMode.GetGameMode();
        GM.OnDistanceUpdate += DistanceUpdate;
        txtDistance.gameObject.SetActive(false);

        PauseMenu.SetActive(false);
    }

    //Deals with showing UI after the count down has finished
    public void OnCountDownFinished()
    {
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
        InGameGameMode.GetGameMode().PauseGame();
        //hides objects
        btnPause.gameObject.SetActive(false);
        //shows objects
        PauseMenu.SetActive(true);
    }
    //unPauses the game
    void UnPauseGame()
    {
        InGameGameMode.GetGameMode().UnPauseGame();
        //hides objects
        PauseMenu.SetActive(false);
        //shows objects
        btnPause.gameObject.SetActive(true);
    }

}
