using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SahneAtama : MonoBehaviour
{
    public List<Button> buttonList;

    void Start()
    {
        foreach (var button in buttonList)
        {
            Butonnn buttonScript = button.GetComponent<Butonnn>();
            if (buttonScript != null && buttonScript.level <= PlayerPrefs.GetInt("MaxLevel"))
            {
                button.GetComponent<Button>().interactable = true;
            }
        }
    }
}
