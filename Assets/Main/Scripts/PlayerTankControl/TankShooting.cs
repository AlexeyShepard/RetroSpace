using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TankShooting : MonoBehaviour
{
    public Rigidbody m_Shell;           //Ссылка на снаряд
    public Transform m_FireTransform;   //Позиция, где спавниться снаряд
    private bool FireEnable = true;      //Можно сделать выстрел или нет
    private float CountMileSecond = 0;

    private void Update()
    {
        if (Input.GetButton("Fire1") && FireEnable)
        {
            Fire();
            FireEnable = false;
        }
        else if (CountMileSecond == 40)
        {
            FireEnable = true;
            CountMileSecond = 0;
        }
    }

    private void FixedUpdate()
    {
        if (!FireEnable) CountMileSecond += 2;
    }


    public void Fire()
    {
        //Создание снаряда и троектории его полёта
        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        // Установка скорости полёта снаряда
        shellInstance.velocity = 30f * m_FireTransform.forward;
    }
}
