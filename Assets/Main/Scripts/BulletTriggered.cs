using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTriggered : MonoBehaviour
{
    private GameObject m_TextBox;   //Текстбокс счета очков который мы получим по тегу
    private ScoreScript score;      //Компонент скрипт

    private void OnTriggerEnter(Collider other)
    {
        //Срабатывает если в тригер пули попала ракета
        if (other.gameObject.tag == "Rocket")
        {
            RocketMovement rocketMovement = other.gameObject.GetComponent<RocketMovement>();
            
            //Если уничтожена ракета
            m_TextBox = GameObject.FindGameObjectWithTag("ScoreBox");
            score = m_TextBox.GetComponent<ScoreScript>();
            score.ChangeScoreNumber((Convert.ToInt32( rocketMovement.Value + rocketMovement.Value * TankStats.tankMultipValue)));
            //

            rocketMovement.DestroyRocket();
            Destroy(other.gameObject);


        }
        //Срабатывает в триггер пули попал вражеский танк
        if (other.gameObject.tag == "EnemyTank")
        {
            EnemyTankHelth enemyTankHelth = other.gameObject.GetComponent<EnemyTankHelth>();
            enemyTankHelth.TakeDamage();

            //Если хп у танка 0 то по сути он уничтожается, тут это вставил т.к что бы было ну как то структурированно
            if (enemyTankHelth.m_HealthCount == 0)
            {
                m_TextBox = GameObject.FindGameObjectWithTag("ScoreBox");
                score = m_TextBox.GetComponent<ScoreScript>();
                score.ChangeScoreNumber((Convert.ToInt32(enemyTankHelth.Value + enemyTankHelth.Value * TankStats.tankMultipValue)));
            }
        }
    }
}
