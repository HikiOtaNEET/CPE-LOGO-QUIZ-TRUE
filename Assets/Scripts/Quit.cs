using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Quit : MonoBehaviour
{
    public GameObject ConfirmQuit;
    bool state;
   

    
    public void QuitBox()
    {
        
        state = !state;
        ConfirmQuit.SetActive(state);
    }

    // Update is called once per frame
    public void Yesplz()
    {
       ConfirmQuit.SetActive(false);  
    }

    public void Noplz()
    {
         Application.Quit();
    }
}
