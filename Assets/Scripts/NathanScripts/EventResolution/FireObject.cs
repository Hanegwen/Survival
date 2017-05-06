using UnityEngine;
using System.Collections;
using System;

public class FireObject : MonoBehaviour, IActivate
{
    InventoryManager inventory;
    FireEvent fireEvent;

    public string NameText
    {
        get
        {
            return "Put out fire (water)";
        }
    }

    void Awake()
    {
        inventory = FindObjectOfType<InventoryManager>();
        fireEvent = GetComponentInParent<FireEvent>();
    }

    public void DoActivate()
    {
        foreach(InventoryObj obj in inventory.InventoryObjects)
        {
            if(obj is Water)
            {
                Debug.Log("You put out the fire");
                obj.RemoveSelfFromInventory();
                fireEvent.PutOutFire(this.gameObject);
            }
            else
            {
                Debug.Log("You need water to put out the fire!");
            }
        }
    }


    //private void OnMouseDown()
    //{
    //    if(inventory.FirstSelected)
    //    {
    //        InventoryObj objectUsedOn = inventory.FirstSelected.GetComponent<InventoryObj>();
    //        if(objectUsedOn is Water)
    //        {
    //            Debug.Log("You put out the fire");
    //            objectUsedOn.RemoveSelfFromInventory();
    //            fireEvent.PutOutFire(this.gameObject);
    //        }
    //    }
    //}
}
