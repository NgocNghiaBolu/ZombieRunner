using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;//goc nhin t1
    [SerializeField] float range = 100f;//khoang cach ban dc 100m
    [SerializeField] float damage = 20f;
    [SerializeField] ParticleSystem puzzleFlast;
    [SerializeField] GameObject hitEffect;
    [SerializeField] AmmoWeapon ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 1f;


    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;//sau khi ban thi dung lai
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0) //neu so luong ammo > 0 thi thuc hien hanh dong ben duoi
        {
            PuzzleFlastGun();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;//dung lai 1s roi ban tiep
    }

    private void PuzzleFlastGun()
    {
        puzzleFlast.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))//ban ve phia truoc theo huong va co pham vi da chon
        {
            HitEffectImpact(hit);
            EnemyHeath target = hit.transform.GetComponent<EnemyHeath>();//neu ban trung muc tieu thi toi cript Enemyhealth
            //Debug.Log("I hit this something" + hit.transform.name);
            if (target == null) return;
            target.TakeDamage(damage);//muc tieu bi tan cong va tru maus
        }
        else
        {
            return;
        }
    }

    private void HitEffectImpact(RaycastHit hit)
    {
       GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
       Destroy(impact, 0.1f);
    }
}
