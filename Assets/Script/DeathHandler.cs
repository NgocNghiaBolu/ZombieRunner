using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas GameOverCanvas;

    private void Start()
    {
        GameOverCanvas.enabled = false;
    }

    public void HandlerDeath()
    {
        GameOverCanvas.enabled = true;// khi die thi hien len
        Time.timeScale = 0;//thoi gian de choi game dung lai
        FindObjectOfType<WeaponSwicher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;// lic do con chout chi dung duoc button
        Cursor.visible = true;
    }
}
