using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowerRotation : MonoBehaviour
{
    private GameObject PlayerGameObject;    //GameObject игрока
    private Rigidbody PlayerRigidBody;      //РиждитБоди игрока
    public Transform BodyEnemyTank;         //Позиция корпуса танка противника
    private Collider EnteredCollider;       //Коллайдер, который попал в триггер танка противника
    private bool InTrigger = false;         //Переменная в которой хранится информация, если игрок в триггере танка противника

    private void Awake()
    {
        PlayerGameObject = GameObject.FindGameObjectWithTag("Player");
        PlayerRigidBody = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position = new Vector3(BodyEnemyTank.transform.position.x, 0.57f, BodyEnemyTank.transform.position.z);
    }
    
    private void FixedUpdate()
    {

        Vector3 VectorToPlayer = PlayerGameObject.transform.position - transform.position;

        VectorToPlayer.y = 0f;

        Quaternion NewRotation = Quaternion.LookRotation(VectorToPlayer);
        PlayerRigidBody.MoveRotation(NewRotation);     
    }

    
    private void OnTriggerEnter(Collider other)
    {
        //Если игрок в триггере то InTrigger = true
        if (other.gameObject.tag == "Player")
        {
            EnteredCollider = other;
            InTrigger = !InTrigger;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Если игрок не в триггере то InTrigger = false
        if (other.gameObject.tag == "Player")
        {
            InTrigger = !InTrigger;
            EnteredCollider = null;
        }
            
    }

    //Возвращает значение игрок в коллайдере или нет
    public bool ReturnCollider()
    {
        return InTrigger;
    }
}
