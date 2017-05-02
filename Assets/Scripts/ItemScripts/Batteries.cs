using UnityEngine;
using System.Collections;

public class Batteries : InventoryObj
{
    void Awake()
    {
        itemType = ItemType.ELECTRIC;
    }
}
