﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadByIndex(int sceneIndex)
    {
        MenuPause.timing = 1f;
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneIndex);
    }
}
