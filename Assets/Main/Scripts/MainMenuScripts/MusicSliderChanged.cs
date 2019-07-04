using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSliderChanged : MonoBehaviour
{
    public AudioSource music;
    public Slider slider;
    public static float musicValue = 1;

    void Start()
    {
        if (PauseMenuMusicVolume.musicValue != 1)
        {
            musicValue = PauseMenuMusicVolume.musicValue;
            music.volume = PauseMenuMusicVolume.musicValue;
            slider.value = PauseMenuMusicVolume.musicValue;
        }
        music.volume = slider.value;
    }
    
    void Update()
    {
        music.volume = slider.value;
        musicValue = slider.value;
    }
}
