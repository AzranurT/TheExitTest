using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashboardUI : MonoBehaviour
{
    public Butonnn butonnn;
    public Text text;

    private void Start()
    {
        text.text=PlayerPrefs.GetInt("DeadCount"+butonnn.level,0).ToString();
    }
}
