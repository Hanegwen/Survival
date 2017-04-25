using UnityEngine;
using System.Collections;
using System;

public class BreakerBox : MonoBehaviour, IActivate
{
    [SerializeField]
    GameObject lightContainerGameObject;

    public bool isBreakerBoxWorking = true;
    bool breakerBoxIsActivated = true;

    public string NameText
    {
        get { return "Breaker Box"; }
    }

    public bool IsElectricityOn
    {
        //return lightContainerGameObject.activeSelf;
        get { return breakerBoxIsActivated && isBreakerBoxWorking; }
    }

    private void OnMouseDown()
    {
        DoActivate();
    }

    public void DoActivate()
    {
        if (isBreakerBoxWorking)
        {
            if (lightContainerGameObject.activeSelf)
            {
                lightContainerGameObject.SetActive(false);
                breakerBoxIsActivated = false;
                ActivateLookedAtObject.shouldShowDisplayText = false;
            }
            else
            {
                lightContainerGameObject.SetActive(true);
                breakerBoxIsActivated = true;
                ActivateLookedAtObject.shouldShowDisplayText = true;
            }
        }
    }


}