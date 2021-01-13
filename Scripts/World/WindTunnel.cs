using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class WindTunnel : MonoBehaviour
{
    //set the force amount and direction to push the player in
    [Header("Gameplay")]
    public float force = 10;
    public Vector3 Direction;

    private void OnTriggerEnter(Collider other)
    {
        //get the player controller of the object that entered the trigger
        PlayerController PC = other.gameObject.GetComponent<PlayerController>();
        //if not a player, return
        if (!PC) return;
        //else add the wind force to the player.
        PC.AddForce(Direction.normalized, force);
    }
}
