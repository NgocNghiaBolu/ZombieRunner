using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas impactDamage;
    [SerializeField] float impactTime = 0.4f;

    void Start()
    {
        impactDamage.enabled = false;
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ShowSplatter());
    }

    IEnumerator ShowSplatter()
    {
        impactDamage.enabled = true;
        yield return new WaitForSeconds(impactTime);
        impactDamage.enabled = false;
    }
}
