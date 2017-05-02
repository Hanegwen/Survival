using UnityEngine;
using System.Collections;

public class Flashlight : InventoryObj
{
    static Light flashlight;
    private static bool flashLightOutOfBatteries = false;
    public static bool FlashlightDisabledOrOutOfBatteries { get { return flashLightOutOfBatteries || !flashlight.enabled; } }

    [SerializeField] float flashlightChargeDecayRate = 5;

    [SerializeField] float flashlightChargeStart = 100f;
    float flashlightCharge;
    float flashlightStartIntensity;

    void Start()
    {
        itemType = ItemType.ELECTRIC;

        flashlight = GetComponentInChildren<Light>();
        if(!flashlight)
        {
            throw new System.Exception("Flashlight script: There is no child with a light attached to it!");
        }

        flashlightCharge = flashlightChargeStart;
        flashlightStartIntensity = flashlight.intensity;

        flashlight.enabled = false;

    }

    public override void UseItemOn(InventoryObj itemToUseOn)
    {
        Debug.Log("Used " + itemToUseOn + " on " + this);
        if(!itemToUseOn)
        {
            TurnOnOffFlashlight();
        }
        if (itemToUseOn is Batteries)
        {
            Debug.Log("Used batteries");
            RechargeFlashlight();
            itemToUseOn.RemoveSelfFromInventory();
        }
    }


    public void TurnOnOffFlashlight()
    {
        if (flashlight.enabled)
        {
            flashlight.enabled = false;
        }
        else
        {
            flashlight.enabled = true;
        }
    }

    public void RechargeFlashlight()
    {
        flashlightCharge = flashlightChargeStart;
        flashlight.intensity = flashlight.intensity = flashlightStartIntensity;
    }

    void Update()
    {
        if (flashlight.enabled)
        {
            if (flashlight.intensity > 0)
            {
                flashlightCharge -= flashlightChargeDecayRate * Time.deltaTime;

                //change the ratio of the flashlight's intensity based on 
                flashlight.intensity = (flashlightCharge / flashlightChargeStart) * flashlightStartIntensity;
                flashLightOutOfBatteries = false;
            }
            else
            {
                flashlight.intensity = 0;
                flashLightOutOfBatteries = true;
            }
        }
    }
}
