using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Vector3 openPosition; // Kapýnýn açýk konumu
    public float openSpeed = 1f; // Kapýnýn açýlma hýzý
    public float closeSpeed = 2f; // Kapýnýn kapanma hýzý

    private Vector3 initialPosition; // Kapýnýn baþlangýç konumu
    private bool isOpen = false; // Kapýnýn açýk olup olmadýðýný kontrol etmek için

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (isOpen)
        {
            // Kapýyý yavaþça aç
            transform.position = Vector3.Lerp(transform.position, openPosition, Time.deltaTime * openSpeed);
        }
        else
        {
            // Kapýyý yavaþça kapat
            transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime * closeSpeed);
        }
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen; // Kapýnýn durumunu tersine çevir
    }
}
