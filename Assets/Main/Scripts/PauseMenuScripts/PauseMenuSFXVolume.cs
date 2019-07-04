using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuSFXVolume : MonoBehaviour
{
    public AudioSource sound;
    public Slider slider;
    public static float SFXValue = 1;

    void Start()
    {
        if (MusicSliderChanged.musicValue != 1)
        {
            SFXValue = SFXSliderChanged.SFXValue;
            sound.volume = SFXSliderChanged.SFXValue;
            slider.value = SFXSliderChanged.SFXValue;
        }
        sound.volume = slider.value;
    }

    void Update()
    {
        sound.volume = slider.value;
        SFXValue = slider.value;
    }
}
