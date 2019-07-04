using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject[] m_Enemy;              // GameObject врага
    public float m_SpawnTime = 3f;            // Промежуток между спавнами противника
    public ParticleSystem m_ParticleSystem;   // Частицы ставна персонажа 


    void Start()
    {
        // Выполняет данный метод каждые 3 сек
        m_SpawnTime = DifficultSelection.difficultValue;
        InvokeRepeating("Spawn", m_SpawnTime, m_SpawnTime);
    }


    void Spawn()
    {
        // С помощью рандома, возвращает случайный индекс массива
        int EnemyIndex = Random.Range(0, m_Enemy.Length);

        switch (EnemyIndex)
        {
            case 0:
                {
                    Vector3 RandomPlace = new Vector3(Random.Range(-20f, 20f), 0.5f, Random.Range(-20f, 20f));
                    Instantiate(m_Enemy[EnemyIndex], RandomPlace, Quaternion.identity);
                    m_ParticleSystem.transform.position = RandomPlace;
                    m_ParticleSystem.Play();
                    break;
                }
            case 1:
                {
                    Vector3 RandomPlace = new Vector3(Random.Range(-20f, 20f), 0f, Random.Range(-20f, 20f));
                    Instantiate(m_Enemy[EnemyIndex], RandomPlace, Quaternion.identity);
                    m_ParticleSystem.transform.position = RandomPlace;
                    m_ParticleSystem.Play();
                    break;
                }
        }       
    }
}
