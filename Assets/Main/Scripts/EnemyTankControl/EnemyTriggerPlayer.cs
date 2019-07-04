using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ReturnCollider(other);
    }

    public Collider ReturnCollider(Collider other)
    {
        return other;    
    }
}
