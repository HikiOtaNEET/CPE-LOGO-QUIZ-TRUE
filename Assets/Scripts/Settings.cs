using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject panel;
    bool state;

    public void OpenPanel()
    {

        state = !state;
        panel.SetActive(state);
    }
    public void ClosePanel()
    {
        panel.SetActive(false);   
    }
}
