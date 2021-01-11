using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    private static WorldGen instance;
    //public getter for the gamemode instance
    public static WorldGen GetGameMode() { return instance; }

    private void Awake()
    {
        //sets up the gamemode instance
        if (instance)
            Destroy(this);
        instance = this;

        SetUpQueues();
    }

    //Pool System
    [Header("Object Pool")]
    public GameObject[] Backgrounds;
    Queue<GameObject> ActiveBackgrounds = new Queue<GameObject>();
    public GameObject[] Pipes;
    Queue<GameObject> ActivePipes = new Queue<GameObject>();

    void SetUpQueues()
    {
        ActiveBackgrounds.Clear();

        for(int i = 0; i < Backgrounds.Length; i++)
        {
            ActiveBackgrounds.Enqueue(Backgrounds[i]);
        }

        for (int i = 0; i < Pipes.Length; i++)
        {
            ActivePipes.Enqueue(Pipes[i]);
        }
    }

    int step = 3;

    void GenerateNextSection()
    {
        //Spawn the background
        GameObject newBackground = ActiveBackgrounds.Dequeue();
        newBackground.transform.position = new Vector3(10 * step, 0, 0);
        ActiveBackgrounds.Enqueue(newBackground);
        //Spawn the pipes to avoid
        //randomly choose between the first two pipes
        GameObject newPipe = ActivePipes.Dequeue();
        GameObject newPipe1 = ActivePipes.Dequeue();
        //50/50 chance of spawning either pipe
        if (Random.value > .5f)
        {
            //add the non chosen pipe to the queue first
            ActivePipes.Enqueue(newPipe);
            newPipe = newPipe1;
        }
        else
            ActivePipes.Enqueue(newPipe1);

        float yValue = Random.Range(-.6f, .6f);
        float xValue = Random.Range(-2.5f, 2.5f);
        newPipe.transform.position = new Vector3(10 * step + xValue, yValue, -2.5f);

        //then add the last pipe to the queue
        ActivePipes.Enqueue(newPipe);
        //increament the step away from start point
        step++;
    }

    //temp
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            GenerateNextSection();
    }

}
