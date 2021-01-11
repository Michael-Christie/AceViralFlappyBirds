using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    private static WorldGen instance;
    //public getter for the gamemode instance
    public static WorldGen GetWorld() { return instance; }

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
    public ParticleSystem ClearedGapParticles;

    void SetUpQueues()
    {
        ActiveBackgrounds.Clear();

        for (int i = 0; i < Backgrounds.Length; i++)
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
        GameObject newPipe = ActivePipes.Dequeue();
        GameObject newPipe1 = ActivePipes.Dequeue();

        float yValue = Random.Range(-.6f, .6f);
        float xValue = Random.Range(-1.5f, 1.5f);
        newPipe.transform.position = new Vector3(10 * step + xValue, yValue, -2.5f);

        newPipe1.transform.position = new Vector3(10 * step + xValue + 5, yValue, -2.5f);

        //then add the pipes back to the list
        ActivePipes.Enqueue(newPipe);
        ActivePipes.Enqueue(newPipe1);
        //increament the step away from start point
        step++;
    }

    //temp
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            GenerateNextSection();
    }

    private void OnTriggerEnter(Collider other)
    {
        //The player has entered the trigger

        //Moves the trigger area to the next section
        transform.position = new Vector3(10 * (step - 1), 0, -2);
        //generates a new section
        GenerateNextSection();
    }

    public void PlayParticles(Vector3 Location)
    {
        ClearedGapParticles.transform.position = Location;

        ClearedGapParticles.Play();
    }

}
