using UnityEngine;
using System.Collections;

public class GasLeakObject : MonoBehaviour, IActivate
{
    InventoryManager inventory;
    ChainEvent gasLeak;

    public string NameText
    {
        get
        {
            return "Fix gas pipe (wrench)";
        }
    }

    void Awake()
    {
        inventory = FindObjectOfType<InventoryManager>();
        gasLeak = GetComponentInParent<ChainEvent>();
    }

    public void DoActivate()
    {
        foreach (InventoryObj obj in inventory.InventoryObjects)
        {
            if (obj is Wrench)
            {
                Debug.Log("You stopped the gas leak");
                gasLeak.StopChain();
                gameObject.SetActive(false);

            }
            else
            {
                Debug.Log("You need a wrench to stop the gas leak!");
            }
        }
    }
}
