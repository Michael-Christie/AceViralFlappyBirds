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
    public GameObject[] Obsticles;
    Queue<GameObject> ActivePipes = new Queue<GameObject>();
    public ParticleSystem ClearedGapParticles;

    //the distance from the start
    int step = 3;

    void SetUpQueues()
    {
        //queues the backgrounds
        ActiveBackgrounds.Clear();
        for (int i = 0; i < Backgrounds.Length; i++)
        {
            ActiveBackgrounds.Enqueue(Backgrounds[i]);
        }
        //queues the pipes
        ActivePipes.Clear();
        for (int i = 0; i < Obsticles.Length; i++)
        {
            ActivePipes.Enqueue(Obsticles[i]);
        }
    }

    void GenerateNextSection()
    {
        //Spawn the background
        //if the step number is an even
        if ((step & 1) == 0)
        {
            //move the background along
            GameObject newBackground = ActiveBackgrounds.Dequeue();
            newBackground.transform.position = new Vector3(10 * step, 0, 0);
            ActiveBackgrounds.Enqueue(newBackground);
        }
        //Spawn the pipes to avoid

        for (int i = 0; i < 2; i++)
        {
            //dequeue the first pipe object
            GameObject newPipe = ActivePipes.Dequeue();
            //randomly chose a height
            float yValue = Random.Range(-1.2f, 1.2f);
            //move the pipe object to the new location
            newPipe.transform.position = new Vector3(5 * (step * 2 + i) , yValue, -2.5f);
            //add it back to the end of the queue
            ActivePipes.Enqueue(newPipe);
        }

        //increament the step away from start point
        step++;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if its not the player... return;
        if (!other.gameObject.GetComponent<PlayerController>()) return;

        //Moves the trigger area to the next section
        transform.position = new Vector3(10 * (step - 1), 0, -2);
        //generates a new section
        GenerateNextSection();
    }

    //Plays the particle system at a location...
    public void PlayParticles(Vector3 Location)
    {
        ClearedGapParticles.transform.position = Location;

        ClearedGapParticles.Play();
    }

}
