using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Text textBoxHealth;

    public int health;

    private Animator anim;

    public GameObject deathScreen;
    public GameObject Menu;
    public GameObject pauseOptions;
    public GameObject pauseMenuMain;

    public GameObject m_PlayerTank;
    public GameObject m_PlayerTankBody;
    public GameObject m_SpawnSystem;
    public ParticleSystem m_PlayerExplosion;

    void Start()
    {
        health = Convert.ToInt32(TankStats.tankHPValue);
        ChangeShieldsText();
        deathScreen.SetActive(false);
    }
    
    public void ChangeShieldsText()
    {
        switch (health)
        {
            case 0:
                {
                    pauseMenuMain.SetActive(false);
                    pauseOptions.SetActive(false);
                    deathScreen.SetActive(true);
                    Menu.SetActive(true);
                    MenuPause.isPaused = true;
                    MenuPause.timing = 0.5f;
                    anim = deathScreen.GetComponent<Animator>();
                    anim.SetTrigger("Open");
                    m_PlayerExplosion.transform.position = m_PlayerTankBody.transform.position;
                    m_PlayerExplosion.Play();
                    Destroy(m_PlayerTank);
                    Destroy(m_SpawnSystem);
                    break;
                }
            case 1:
            case 2:
            case 3:
                {
                    textBoxHealth.color = Color.red;
                    break;
                }
            case 4:
            case 5:
            case 6:
                {
                    textBoxHealth.color = Color.yellow;
                    break;
                }
            default:
                {
                    textBoxHealth.color = Color.green;
                    break;
                }
        }
        textBoxHealth.text = "Shields: " + health;
    }

    public void ChangeShieldsNumber(int number)
    {
        health = health - number;
        ChangeShieldsText();
    }
}
