using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeath : MonoBehaviour
{
    [SerializeField] float HitPoint = 200f;
    public float ShootTime = 0.2f;
    public AudioClip AuZombDie;

    //private bool isDead = false;
    public static AudioSource AuzombRun;//static de tham chieu qua PlayerHealth tat sound
    private Animator animGetHit;
    private bool isShooten;

    public bool IsShooten //Dong goi
    {
        get { return isShooten; }
        set
        {
            isShooten = value;
            SetGetHit(isShooten);
            UpdateShootenTime();
        }
    }

    private float ShootenLastTime = 0f;
    void Start()
    {
        AuzombRun = GetComponent<AudioSource>();
        animGetHit = GetComponent<Animator>();
        IsShooten = false;
    }

    void UpdateShootenTime()
    {
        ShootenLastTime = Time.time;
    }

    void SetGetHit(bool isShooten)
    {
        animGetHit.SetBool("getHit", isShooten);
    }

    bool isDie = false;
    public bool IsDied()
    {
        return isDie;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageEnemy");
        AuzombRun.Play();
        IsShooten = true;
        HitPoint -= damage;//ban trung tru di so diem quy dinh
        if (HitPoint <= 0)
        {
            if (EnemyHeath.AuzombRun != null)
            {
                EnemyHeath.AuzombRun.Stop();
                EnemyHeath.AuzombRun.PlayOneShot(AuZombDie);
            }
            Die();
        }
    }

    private void Die()
    {
        if (isDie) return;
        isDie = true;
        GetComponent<Animator>().SetTrigger("Die");
    }

    private void Update()
    {
        if (IsShooten && Time.time >= ShootenLastTime + ShootTime)
        {
            IsShooten = false;
        }
    }
}
