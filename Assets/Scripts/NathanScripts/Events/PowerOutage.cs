using UnityEngine;
using System.Collections;
using System;

public class PowerOutage : IEvent
{
    [SerializeField] BreakerBox breakerBox;
    [SerializeField] GameObject LightContainer;

    public override void ActivateEvent()
    {
        if(breakerBox.IsElectricityOn)
        {
            LightContainer.SetActive(false);
            ActivateLookedAtObject.shouldShowDisplayText = false;
            breakerBox.isBreakerBoxWorking = false;
        }
    }

}
