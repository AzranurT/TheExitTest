using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Butonnn : MonoBehaviour
{
    public int level;

    private void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("MaxLevel"));
    }

    public void StartGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentScene")); 
    }
    public void QuitGame()
    {
        Debug.Log("Oyundan çýkýlýyor...");
        Application.Quit();
    }
    public void Giris()
    {
        SceneManager.LoadScene(0); 
    }
    public void Seviye()
    {
        SceneManager.LoadScene(1); 
    }
    public void One()
    {
        SceneManager.LoadScene(5); 
    }
    public void Two()
    {
        SceneManager.LoadScene(6); 
    }
    public void BastanBasla()
    {
        SceneManager.LoadScene(Sahne.Instance.currentScene);
    }
    public void Three()
    {
        SceneManager.LoadScene(7); 
    }
}