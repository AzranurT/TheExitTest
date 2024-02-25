using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Vector3 openPosition; // Kap�n�n a��k konumu
    public float openSpeed = 1f; // Kap�n�n a��lma h�z�
    public float closeSpeed = 2f; // Kap�n�n kapanma h�z�

    private Vector3 initialPosition; // Kap�n�n ba�lang�� konumu
    private bool isOpen = false; // Kap�n�n a��k olup olmad���n� kontrol etmek i�in

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (isOpen)
        {
            // Kap�y� yava��a a�
            transform.position = Vector3.Lerp(transform.position, openPosition, Time.deltaTime * openSpeed);
        }
        else
        {
            // Kap�y� yava��a kapat
            transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime * closeSpeed);
        }
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen; // Kap�n�n durumunu tersine �evir
    }
}
