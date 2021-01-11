using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMoveForward : MonoBehaviour
{
    [SerializeField]
    int speed;

    InGameGameMode GM;

    private void Start()
    {
        GM = InGameGameMode.GetGameMode();
    }

    private void Update()
    {
        if (GM.IsGameRunning())
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            GM.AddDistanceTraveled(speed * Time.deltaTime);
        }
    }
}
