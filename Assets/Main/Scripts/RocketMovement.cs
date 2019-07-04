using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    private GameObject m_Player;                //Gameobject игрока 
    private Rigidbody m_RigidBody;              //Риждитбоди ирока
    private Vector3 Trajectory;                 //Траектория от ракеты до игрока
    private Vector3 TrajectoryRotation;         //Траектория поворта для ракеты
    public ParticleSystem m_ExplosionParticle;  //Частицы взрыва 
    private float Speed;

    public int Value = 100;                     //Кол-во очков за ракету
    private GameObject m_TextBox;               //Поиск по тегу текстбокса HealthBox
    private HealthScript health;                //Компонент скрипт

    private void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_RigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Speed += 0.5f;
        Trajectory = (m_Player.transform.position - transform.position) * Time.deltaTime * Speed * 0.1f;
        m_RigidBody.MovePosition(m_RigidBody.position + Trajectory);

        TrajectoryRotation = m_Player.transform.position - transform.position;

        TrajectoryRotation.y = 0f;
        Quaternion turnRotation = Quaternion.LookRotation(TrajectoryRotation);
        m_RigidBody.MoveRotation(turnRotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Если в триггер ракеты попадает игрок, то она удаляется
        if (other.gameObject.tag == "Player")
        {
            DestroyRocket();            
            Destroy(gameObject);

            m_TextBox = GameObject.FindGameObjectWithTag("HealthBox");
            health = m_TextBox.GetComponent<HealthScript>();
            health.ChangeShieldsNumber(1);
        }
    }

    //Удаление ракеты
    public void DestroyRocket()
    {
        m_ExplosionParticle.transform.parent = null;
        m_Player.GetComponent<Rigidbody>().AddExplosionForce(300f, transform.position, 5f);
        m_ExplosionParticle.Play();
    }
}
