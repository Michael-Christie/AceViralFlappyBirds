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
        btnHat.onClick.AddListener(onHatPressed);

        LockedText.GetComponent<Text>().text = "UNLOCKED AT " + unlockedAt.ToString() + "m";
    }

    public void UpdateHat(bool bIsSelected, int CurrentHighScore)
    {
        Debug.Log(bIsSelected);

        if(CurrentHighScore >= unlockedAt)
        {
            bIsUnlocked = true;
            LockedText.SetActive(false);
            btnHat.interactable = true;
        }
        else
        {
            bIsUnlocked = false;
            LockedText.SetActive(true);
            btnHat.interactable = false;
        }

        if(bIsSelected)
            selectedImage.color = SelectedColor;
        else
            selectedImage.color = notSelectedColor;
    }

    void onHatPressed()
    {
        if(bIsUnlocked)
         FindObjectOfType<MainMenuWidget>().SelectNewHat(Hat);
    }

}
