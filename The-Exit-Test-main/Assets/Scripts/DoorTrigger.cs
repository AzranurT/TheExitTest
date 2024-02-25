using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public DoorController door; // Kapý kontrolcüsü

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.ToggleDoor(); // Kapýyý aç
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.ToggleDoor(); // Kapýyý kapat
        }
    }
}
