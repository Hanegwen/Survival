using UnityEngine;
using System.Collections;

public class Water : InventoryObj
{
    [SerializeField] float increaseThirstAmount = 10;
    Player player;

    void Start()
    {
        itemType = ItemType.DRINK;

        player = FindObjectOfType<Player>();
        if (!player)
            throw new System.Exception("There is no gameObject with a \"Player\" script in the scene!");
    }

    public override void UseItemOn(InventoryObj itemToUseOn)
    {
        if (!itemToUseOn)
        {
            player.Thirst += increaseThirstAmount;
            RemoveSelfFromInventory();
        }
    }
}
