using UnityEngine;
using System.Collections;
using System;

public class FireObject : MonoBehaviour, IActivate
{
    [SerializeField] float damageToDeal = 2.5f;

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

    void OnTriggerStay(Collider coll)
    {
        Player player = coll.gameObject.GetComponent<Player>();
        if(player)
        {
            Debug.Log(player);
            player.Health -= damageToDeal * Time.deltaTime;
        }
    }
}
