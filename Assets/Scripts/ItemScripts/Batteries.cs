using UnityEngine;
using System.Collections;

public class Batteries : InventoryObj
{
    Flashlight flashLight;
    void Awake()
    {
       flashLight = FindObjectOfType<Flashlight>();
        itemType = ItemType.ELECTRIC;
    }

    public override void UseItemOn(InventoryObj itemToUseOn)
    {

        if (itemToUseOn is Flashlight)
        {
            Debug.Log("Used batteries");
            flashLight.RechargeFlashlight();
            RemoveSelfFromInventory();
            
        }
    }
}
