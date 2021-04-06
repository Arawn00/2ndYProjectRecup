using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public GameObject platform;
    public GameObject player;


   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = platform.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
