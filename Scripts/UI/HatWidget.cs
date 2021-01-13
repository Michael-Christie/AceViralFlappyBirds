using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatWidget : MonoBehaviour
{
    [Header("Hat Options")]
    [SerializeField]
    Color SelectedColor;
    [SerializeField]
    Color notSelectedColor;
    public GameObject Hat;
    [SerializeField]
    int unlockedAt;
    bool bIsUnlocked;

    [Header("UI")]
    [SerializeField]
    Button btnHat;
    [SerializeField]
    Image selectedImage;
    [SerializeField]
    GameObject LockedText;

    private void Start()
    {
        //add the button click event
        btnHat.onClick.AddListener(onHatPressed);
        //update the text component
        LockedText.GetComponent<Text>().text = "UNLOCKED AT " + unlockedAt.ToString() + "m";
    }

    public void UpdateHat(bool bIsSelected, int CurrentHighScore)
    {
        //if the hat is unlocked
        if(CurrentHighScore >= unlockedAt)
        {
            bIsUnlocked = true;
            //hide the locked texxt and set the button as interactable
            LockedText.SetActive(false);
            btnHat.interactable = true;
        }
        else
        {
            bIsUnlocked = false;
            //show the locked text and set the button as uninteractable
            LockedText.SetActive(true);
            btnHat.interactable = false;
        }

        //set the selected color if the hat is selected
        if(bIsSelected)
            selectedImage.color = SelectedColor;
        else
            selectedImage.color = notSelectedColor;
    }

    void onHatPressed()
    {
        //set the selected hat to this hat
        if (bIsUnlocked)
        {
            FindObjectOfType<MainMenuWidget>().SelectNewHat(Hat);
            SoundManager.GetSoundManager()?.PlayButtonPressed();
        }
    }

}
