using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] float spotAngleDecay = 0.5f;
    [SerializeField] float intensityDecay = 0.1f;
    [SerializeField] float miniAngle = 10f;
    Light myLight;
    
    
    private void Start()
    {
        myLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseIntensity();
    }

    public void restoreAngle(float retoreangle)
    {
        myLight.spotAngle = retoreangle;
    }

    public void AddintensityLight(float intensityAmount)
    {
        myLight.intensity += intensityAmount;
    }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= miniAngle)
        {
            return;
        }
        else
        {
            myLight.spotAngle -= spotAngleDecay * Time.deltaTime;
        }
    }

    private void DecreaseIntensity()
    {
        myLight.intensity -= intensityDecay * Time.deltaTime;
    }

}
