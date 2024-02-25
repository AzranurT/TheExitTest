using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public DoorController door; // Kap� kontrolc�s�

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.ToggleDoor(); // Kap�y� a�
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.ToggleDoor(); // Kap�y� kapat
        }
    }
}
