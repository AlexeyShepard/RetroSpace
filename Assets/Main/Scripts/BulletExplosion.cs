using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{

    public LayerMask m_TankMask;                        // Маска игрока и противников
    public ParticleSystem m_ExplosionParticles;         // Ссылка на частицы взырва снаряда 
    //public AudioSource m_ExplosionAudio;              // Ссылка на звук взрыва
    public float m_ExplosionForce = 1000f;              // Количество силы, которое дается из эпицентра взрыва
    public float m_MaxLifeTime = 5f;                    // Время жизни снаряда
    public float m_ExplosionRadius = 5f;                // Радиус взрыва

    private GameObject m_TextBox;               //Поиск по тегу текстбокса HealthBox
    private HealthScript health;                //Компонент скрипт

    private void Start()
    {
        // Уничтожение снаряда после двух секундя спустя его создание
        Destroy(gameObject, m_MaxLifeTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_TextBox = GameObject.FindGameObjectWithTag("HealthBox");
            health = m_TextBox.GetComponent<HealthScript>();
            health.ChangeShieldsNumber(1);
        }
        if (other.gameObject.tag != "EnemyTankTowerCollider")
        {
            // Собирает в массив всех колайдеры данной маски, которые входят в сферу
            Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);

            // Проход по всем коллайдерам
            for (int i = 0; i < colliders.Length; i++)
            {
                //Поиск риджитбоди по всем компонентам объекта которому принадлежит коллайдер
                Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

                // Если у коллайдера нет риджитбоди, то пропускает итерацию
                if (!targetRigidbody)
                    continue;

                // Добавляет симуляцию силы взрыва этому риджитбоди
                targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

                // Поиск скрипта связанного с жизнями игрока
                //TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();

                

                // Если скрипта с жизнями нет, то идёт к следующей итерации
                //if (!targetHealth)
                //    continue;

                //Нанесение урона
                //targetHealth.TakeDamage(100f);
            }

            // Убирает родителя у частиц взрыва
            m_ExplosionParticles.transform.parent = null;

            // Проигрывает анимацию частиц взрыва
            m_ExplosionParticles.Play();

            // Проигрывает звук взрыва
            //m_ExplosionAudio.Play();

            // Уничтожает частицы после их проигрывания
            Destroy(m_ExplosionParticles.gameObject, 2f);

            // Уничтожает снаряд
            Destroy(gameObject);
        }       
    }
}
