using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    public AudioSource btnFx;
    public AudioClip clickFx;

    public void ClickSound()
    {
        btnFx.PlayOneShot (clickFx);
    }
}
