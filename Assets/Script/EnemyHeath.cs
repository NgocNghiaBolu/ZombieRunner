using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeath : MonoBehaviour
{
    [SerializeField] float HitPoint = 200f;

    bool isDie = false;
    public bool IsDied()
    {
        return isDie;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageEnemy");
        HitPoint -= damage;//ban trung tru di so diem quy dinh
        if(HitPoint <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDie) return;
        isDie = true;
        GetComponent<Animator>().SetTrigger("Die");
    }
}
