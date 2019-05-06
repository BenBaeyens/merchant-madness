using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHitboxScript : MonoBehaviour
{
    public bool isPlayerInRange = false;

    private void OnTriggerEnter(Collider other) {
        if(other.name == "Player")
            isPlayerInRange = true;
    }
    private void OnTriggerExit(Collider other) {
        if(other.name == "Player")
            isPlayerInRange = false;
    }
}
