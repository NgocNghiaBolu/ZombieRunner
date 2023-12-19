using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomWeapon : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera fpsCamera;
    [SerializeField] FirstPersonController fpsController;
    [SerializeField] float ZoomOutFOV = 40f;
    [SerializeField] float ZoomInFOV = 10f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = 0.5f;
    //[SerializeField] float ZoomSmooth = 5f;

    bool CheckZoomed = false;

    private void OnDisable()
    {
        ZoomOut();
    }

    private void Start()
    {
        fpsController = GetComponent<FirstPersonController>();
    }

    public void Zoom(bool zoomedIn)
    {
        fpsCamera.m_Lens.FieldOfView = zoomedIn ? ZoomInFOV : ZoomOutFOV;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (CheckZoomed == false)
            {
                NewMethod();

            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomOut()
    {
        CheckZoomed = false;
        fpsCamera.m_Lens.FieldOfView = ZoomOutFOV;
        fpsController.RotationSpeed = zoomOutSensitivity;
    }

    private void NewMethod()
    {
        CheckZoomed = true;
        fpsCamera.m_Lens.FieldOfView = ZoomInFOV;
        fpsController.RotationSpeed = zoomInSensitivity;
    }
}



