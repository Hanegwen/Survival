using UnityEngine;
using System.Collections;

public class FloodObject : MonoBehaviour, IActivate
{
    InventoryManager inventory;
    ChainEvent floodLeak;

    public string NameText
    {
        get
        {
            return "Fix water pipe (wrench)";
        }
    }

    void Awake()
    {
        inventory = FindObjectOfType<InventoryManager>();
        floodLeak = GetComponentInParent<ChainEvent>();
    }

    public void DoActivate()
    {
        foreach (InventoryObj obj in inventory.InventoryObjects)
        {
            if (obj is Wrench)
            {
                Debug.Log("You stopped the water leak");
                floodLeak.StopChain();
                gameObject.SetActive(false);

            }
            else
            {
                Debug.Log("You need a wrench to stop the water leak!");
            }
        }
    }
}
