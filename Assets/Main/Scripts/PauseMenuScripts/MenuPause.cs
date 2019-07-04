using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public static float timing;
    public static bool isPaused;
    public GameObject pauseMenu;

    private bool menuPaused = false;
    public GameObject pauseOptions;
    public GameObject pauseMenuMain;
    public GameObject deathScreen;
    public GameObject exitFromMenu;

    private Animator anim;
    private Animator animOpions;
    private Animator deathScreenAnim;
    private Animator exitAnim;

    void Start()
    {
        timing = 1f;
        pauseMenu.SetActive(false);
        pauseOptions.SetActive(false);
        pauseMenuMain.SetActive(false);
        anim = pauseMenuMain.GetComponent<Animator>();
        animOpions = pauseOptions.GetComponent<Animator>();
        deathScreenAnim = deathScreen.GetComponent<Animator>();
        exitAnim = exitFromMenu.GetComponent<Animator>();
    }

    void Update()
    {
        Time.timeScale = timing;
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            pauseOptions.SetActive(false);
            pauseMenuMain.SetActive(true);
            anim.SetTrigger("Open");
            timing = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            isPaused = false;
            if (pauseMenuMain.activeSelf == true)
            {
                anim.SetTrigger("Close");
                timing = 1f;
            }
            else
            {
                animOpions.SetTrigger("Close");
                timing = 1f;
            }
            if (deathScreen.activeSelf == true)
            {
                deathScreenAnim.SetTrigger("Close");
                exitAnim.SetTrigger("Exit");
            }
        }
        if (menuPaused == true)
        {
            menuPaused = false;
            isPaused = false;
            anim.SetTrigger("Close");
            timing = 1f;
        }
    }

    public void ResumeButton(bool state)
    {
        isPaused = state;
        menuPaused = true;
    }
}
