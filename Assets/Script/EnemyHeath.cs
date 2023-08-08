using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeath : MonoBehaviour
{
    [SerializeField] float HitPoint = 200f;

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageEnemy");
        HitPoint -= damage;//ban trung tru di so diem quy dinh
        if(HitPoint <= 0)
        {
            Destroy(gameObject);
        }
    }
}
