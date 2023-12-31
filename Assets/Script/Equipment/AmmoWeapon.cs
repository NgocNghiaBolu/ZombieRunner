using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoWeapon : MonoBehaviour
{
    [SerializeField]
    AmmoSlot[] ammoSlots;

    private AudioSource audi;
    public AudioClip PickupAmmo;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount)
    {
        GetAmmoSlot(ammoType).ammoAmount += ammoAmount;
        CheckPickup();
    }

    void CheckPickup()
    {
        audi = GetComponent<AudioSource>();
        audi.clip = PickupAmmo;
        audi.Play();
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
