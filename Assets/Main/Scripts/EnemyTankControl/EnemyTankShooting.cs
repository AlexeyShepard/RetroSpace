using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankShooting : MonoBehaviour
{
    public Rigidbody m_Shell;                       //Ссылка на снаряд
    public Transform m_FireTransform;               //Позиция, где спавниться снаряд
    private bool FireEnable = true;                 //Можно сделать выстрел или нет
    private float CountMileSecond = 0;              //Для подсчёта милисекунд перед следующим выстрелом
    private EnemyTowerRotation EnemyTowerRotation;  //Скрипт в котором есть нужный метод ReturnCollider

    private void Awake()
    {
        EnemyTowerRotation = GetComponent<EnemyTowerRotation>();
    }

    private void Update()
    {
        //Если можно стрелять и в триггере есть игрок
        if (FireEnable && EnemyTowerRotation.ReturnCollider())
        {
            Fire();
            FireEnable = false;
        }
        else if (CountMileSecond == 50)
        {
            FireEnable = true;
            CountMileSecond = 0;
        }
    }

    private void FixedUpdate()
    {
        if (!FireEnable) CountMileSecond += 1;
    }


    public void Fire()
    {
        //Создание снаряда и троектории его полёта
        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        // Установка скорости полёта снаряда
        shellInstance.velocity = 30f * m_FireTransform.forward;
    }
}
