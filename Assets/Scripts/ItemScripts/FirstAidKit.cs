using UnityEngine;
using System.Collections;

public class FirstAidKit : InventoryObj
{
    [SerializeField] float increaseHealthAmount = 10;
    Player player;

    void Start()
    {
        itemType = ItemType.HEALTH;

        player = FindObjectOfType<Player>();
        if (!player)
            throw new System.Exception("There is no gameObject with a \"Player\" script in the scene!");
    }

    public override void UseItemOn(InventoryObj itemToUseOn)
    {
        if (!itemToUseOn)
        {
            player.Health += increaseHealthAmount;
            //if(player.numberOfWounds > 0)
            //{
            //    player.numberOfWounds--;
            //}

            RemoveSelfFromInventory();
        }
    }
}
