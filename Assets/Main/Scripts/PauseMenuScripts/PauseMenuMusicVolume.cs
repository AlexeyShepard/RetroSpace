using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuMusicVolume : MonoBehaviour
{
    public AudioSource music;
    public Slider slider;
    public static float musicValue = 1;

    void Start()
    {
        if (MusicSliderChanged.musicValue != 1)
        {
            musicValue = MusicSliderChanged.musicValue;
            music.volume = MusicSliderChanged.musicValue;
            slider.value = MusicSliderChanged.musicValue;
        }
        music.volume = slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        music.volume = slider.value;
        musicValue = slider.value;
    }
}
