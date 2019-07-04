using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    private Transform m_Target;      //Местоположение игрока
    private Vector3 m_Offset;       //Разница между камерой и игроком                     

    private void Awake()
    {
        m_Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        //Расчёт разницы между камерой и игроком
        m_Offset = transform.position - m_Target.position;
    }

    private void FixedUpdate()
    {
        //Расчитываем вектор камеры
        Vector3 targetCamPos = m_Target.position + m_Offset;

        //С помощью векторной интерполяции рассчитывает новое положение камеры
        transform.position = Vector3.Lerp(transform.position, targetCamPos, 0.1f);
    }
}
