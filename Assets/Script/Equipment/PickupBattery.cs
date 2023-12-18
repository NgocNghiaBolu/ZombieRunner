using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBattery : MonoBehaviour
{
    [SerializeField] float AddintensityAmount = 1f;
    [SerializeField] float retoreAngle = 30f;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLight>().restoreAngle(retoreAngle);
            other.GetComponentInChildren<FlashLight>().AddintensityLight(AddintensityAmount);
            Destroy(gameObject);
        }
    }
}
