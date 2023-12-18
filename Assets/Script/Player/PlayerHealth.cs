using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float HitPoint = 200f;
    
    //Audio
    private AudioSource AuManHurt;
    public AudioClip AuManDie;
    public Slider BloodSlider;

    public EnemyHeath AudiZom1;
    public EnemyAI AudiZom2;

    private void Start()
    {
        AuManHurt = GetComponent<AudioSource>();
        AudiZom1 = GetComponent<EnemyHeath>();
        AudiZom2 = GetComponent<EnemyAI>();
        //Slider
        BloodSlider.maxValue = HitPoint;
        BloodSlider.value = HitPoint;
        BloodSlider.minValue = 0;
    }

    public void TakeDamage(float damage)
    {
        AuManHurt.Play();
        HitPoint -= damage;//ban trung tru di so diem quy dinh
        BloodSlider.value = HitPoint;//cap nhat lai mau
        if (HitPoint <= 0)
        {
            GetComponent<DeathHandler>().HandlerDeath();
            AuManHurt.clip = AuManDie;
            AuManHurt.Play();

            if (EnemyAI.audi != null && EnemyHeath.AuzombRun != null)
            {
                EnemyAI.audi.Stop();
                EnemyHeath.AuzombRun.Stop();
                // Ho?c ScriptA.AuzombRun.enabled = false
            }
        }
    }
}