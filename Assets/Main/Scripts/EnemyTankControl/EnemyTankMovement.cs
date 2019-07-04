using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankMovement : MonoBehaviour
{
    public float m_Speed = 12f;

    private Rigidbody RigidBody;            //Риджитбоди танка противника    
    private Vector3 WayToPlayer;            //Вектор от танка противника до игрока
    private Vector3 TrajectoryRotation;     //троектория поворота
    private GameObject m_Player;            //GameObject Игрока 

    private void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        RigidBody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();    
    }

    private void Move()
    {
        WayToPlayer = (m_Player.transform.position - transform.position) * m_Speed * Time.deltaTime * 0.05f;
        RigidBody.MovePosition(RigidBody.position + WayToPlayer);

        TrajectoryRotation = m_Player.transform.position - transform.position;
        TrajectoryRotation.y = 0f;
        Quaternion turnRotation = Quaternion.LookRotation(TrajectoryRotation);
        RigidBody.MoveRotation(turnRotation);
    }
}
