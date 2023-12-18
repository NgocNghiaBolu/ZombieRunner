using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAmmo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;
    [SerializeField] AmmoType ammoType;

    //private AudioSource pickupSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<AmmoWeapon>().IncreaseCurrentAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
        } 
    }
}
