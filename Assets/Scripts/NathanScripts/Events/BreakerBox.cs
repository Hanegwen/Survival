using UnityEngine;
using System.Collections;
using System;

public class BreakerBox : MonoBehaviour, IActivate
{
    [SerializeField] GameObject lightContainerGameObject;

    public string NameText
    {
        get { return "Breaker Box"; }
    }

    private void OnMouseDown()
    {
        DoActivate();
    }

    public void DoActivate()
    {
        if(lightContainerGameObject.activeSelf)
        {
            lightContainerGameObject.SetActive(false);
        }
        else
        {
            lightContainerGameObject.SetActive(true);
        }
    }

    public bool IsElectricityOn()
    {
        return lightContainerGameObject.activeSelf;
    }
}
