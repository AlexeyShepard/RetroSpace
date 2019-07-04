using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {

    public float m_Speed = 12f;             //Скорость перемещения
    public float m_TurnSpeed = 180f;        //Скорость поворота 

    private float m_AxisHorizontalValue;    //Значения налево, направо
    private float m_AxisVerticalValue;      //Значения вперёд, назад
    private Rigidbody m_RigidBody;          //РиджитБоди танчика


    //Присвоение переменным компоненты
    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        m_Speed = TankStats.tankSpeedValue + 12f;
    }


    //Получение значения зажатой клавиши, каждый фрейм
    private void Update()
    {
        m_AxisHorizontalValue = Input.GetAxis("Horizontal");
        m_AxisVerticalValue = Input.GetAxis("Vertical");
    }

    //Перемещение и поворот танчика, каждую 0,02 секунды
    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    //Расчёт и перемещение танчика
    private void Move()
    {
        Vector3 movement = transform.forward * m_AxisVerticalValue * m_Speed * Time.deltaTime;

        m_RigidBody.MovePosition(m_RigidBody.position + movement);
    }

    //Расчёт и поворот танчика
    private void Turn()
    {
        float turn = m_AxisHorizontalValue * m_TurnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        m_RigidBody.MoveRotation(m_RigidBody.rotation * turnRotation);
    }
}
