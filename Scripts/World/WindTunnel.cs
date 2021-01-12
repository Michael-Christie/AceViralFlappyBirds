using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class WindTunnel : MonoBehaviour
{
    public float force = 10;

    public Vector3 Direction;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController PC = other.gameObject.GetComponent<PlayerController>();

        if (!PC) return;

        PC.AddForce(Direction.normalized, force);
    }
}
