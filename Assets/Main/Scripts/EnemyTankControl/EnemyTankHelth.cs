using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankHelth : MonoBehaviour
{
    public float m_HealthCount;                 //Кол-во жизней танка
    public GameObject m_FullTank;               //Целый тарк противника
    public ParticleSystem m_ExplosionParticles; //Частицы взрыва

    public int Value = 200; //Цена танка

    //Нанесение урона танку
    public void TakeDamage()
    {
        m_HealthCount -= 1;
    }

    private void FixedUpdate()
    {
        //Если здоровье танка падает до нуля, то уничтожает его
        if (m_HealthCount == 0)
        {
            Destroy(m_FullTank);
            m_ExplosionParticles.transform.parent = null;
            m_ExplosionParticles.Play();
        }
    }

}
