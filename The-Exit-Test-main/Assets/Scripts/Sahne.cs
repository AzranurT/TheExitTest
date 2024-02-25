using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sahne : MonoBehaviour
{
    public PlayerController player;
    public int sahneNumarasi;
    public int currentScene;
    public static Sahne Instance;
    public int counter;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        DontDestroyOnLoad(this.gameObject);
    }

}
