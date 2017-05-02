using UnityEngine;
using System.Collections;

public class Food : InventoryObj
{
    [SerializeField] float increaseHungerAmount = 10;
    Player player;

    void Start()
    {
        itemType = ItemType.FOOD;

        player = FindObjectOfType<Player>();
        if (!player)
            throw new System.Exception("There is no gameObject with a \"Player\" script in the scene!");
    }

    public override void UseItemOn(InventoryObj itemToUseOn)
    {
        if (!itemToUseOn)
        {
            player.hunger += increaseHungerAmount;
            RemoveSelfFromInventory();
        }
    }
}
