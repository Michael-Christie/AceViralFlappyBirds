using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameGameMode : MonoBehaviour
{
    private static InGameGameMode instance;
    //public getter for the gamemode instance
    public static InGameGameMode GetGameMode() { return instance; }

    private void Awake()
    {
        //sets up the gamemode instance
        if (instance)
            Destroy(this);
        instance = this;
    }
}
