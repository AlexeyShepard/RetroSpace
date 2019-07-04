using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuttonHoverAndClick : MonoBehaviour
{
    public AudioSource source;
    public Slider slider;
    
    public void Hit()
    {
        source.volume = slider.value;
        source.Play();
    }

    public void Hover()
    {
        source.volume = slider.value;
        source.Play();
    }
}
