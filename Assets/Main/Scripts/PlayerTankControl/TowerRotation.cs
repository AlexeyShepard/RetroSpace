using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotation : MonoBehaviour
{
    private Rigidbody m_RigidBody;          //Ссылка на РиджитБоди танчика         
    private int m_FloorMask;                //Маска слоя на которой помечается место попадания луча от камеры проходя через мышку
    public float m_CamRayLength = 100f;     //Длина луча от камеры до поверхности маски слоя
    private GameObject m_Body;              //РиджитБоди корпуса танчика для привязки башни

    private void Awake()
    {
        //Создание маски слоя
        m_FloorMask = LayerMask.GetMask("Floor");
        m_RigidBody = GetComponent<Rigidbody>();

        //Привязка РиджитБоди корпуса танчика
        m_Body = GameObject.Find("VoxelTankBody");
    }

    private void Update()
    {
        //Расчёт новой позиции башни на танчике
        transform.position = new Vector3(m_Body.transform.position.x, 0.57f, m_Body.transform.position.z);
    }


    private void FixedUpdate()
    {               
        // Метод поворота башни к позиции курсора
        Turning();
    }


    private void Turning()
    {
        // Создание луча от мышки на экране в сторону камеры
        Ray CamRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Создание переменной в которой хранится, то что попало под луч
        RaycastHit FloorHit;

        // Выполняется если луч касается слоя floor
        if (Physics.Raycast(CamRay, out FloorHit, m_CamRayLength, m_FloorMask))
        {
            // Создаёт вектор от игрока к тому месту, где находится курсор
            Vector3 PlayerToMouse = FloorHit.point - transform.position;

            // Для того, чтобы веткор был вдоль поверхности пола
            PlayerToMouse.y = 0f;

            // Создание поворота исходя из вектора
            Quaternion NewRotation = Quaternion.LookRotation(PlayerToMouse);

            // Установка поворота персонажа
            m_RigidBody.MoveRotation(NewRotation);
        }
    }
}
