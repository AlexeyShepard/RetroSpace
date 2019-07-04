using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSliderChanged : MonoBehaviour
{
    public AudioSource sound;
    public Slider slider;
    public static float SFXValue = 1;

    void Start()
    {
        if (PauseMenuSFXVolume.SFXValue != 1)
        {
            SFXValue = PauseMenuSFXVolume.SFXValue;
            sound.volume = PauseMenuSFXVolume.SFXValue;
            slider.value = PauseMenuSFXVolume.SFXValue;
        }
        sound.volume = slider.value;
    }
    
    void Update()
    {
        sound.volume = slider.value;
        SFXValue = slider.value;
    }
}
