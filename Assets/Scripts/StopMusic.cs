using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    public MusicClass musika;
   
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();
    }
}
