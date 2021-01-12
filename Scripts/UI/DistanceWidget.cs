using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceWidget : MonoBehaviour
{
    [SerializeField]
    Text txtDistance;

    private void Start()
    {
        //get the gamemode and add yourself to the onDistanceUpdate delegate
        InGameGameMode GM = InGameGameMode.GetGameMode();
        GM.OnDistanceUpdate += DistanceUpdate;
        //hide the object till its ready
        gameObject.SetActive(false);
    }

    //updates the text field.
    void DistanceUpdate(float newDistance)
    {
        txtDistance.text = newDistance.ToString("#") + "m";
    }
}
