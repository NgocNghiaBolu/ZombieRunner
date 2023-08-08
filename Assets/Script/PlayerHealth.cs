using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float HitPoint = 200f;

    public void TakeDamage(float damage)
    {
        
        HitPoint -= damage;//ban trung tru di so diem quy dinh
        if (HitPoint <= 0)
        {
            GetComponent<DeathHandler>().HandlerDeath();
        }
    }
}
