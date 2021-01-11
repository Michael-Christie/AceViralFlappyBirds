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
        InGameGameMode GM = InGameGameMode.GetGameMode();
        GM.OnDistanceUpdate += DistanceUpdate;

        gameObject.SetActive(false);
    }

    void DistanceUpdate(float newDistance)
    {
        txtDistance.text = newDistance.ToString("#") + "m";
    }
}
