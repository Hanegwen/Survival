using UnityEngine;
using System.Collections;

public class DustMask : InventoryObj
{
    Player player;

    void Start()
    {
        itemType = ItemType.TOOL;

        player = FindObjectOfType<Player>();
        if(!player)
        {
            throw new System.Exception("There is no gameObject with the script \"Player\" in the scene!");
        }
    }

    public override void UseItemOn(InventoryObj itemToUseOn)
    {
        if(!itemToUseOn)
        {
            if(player.EquipDustMask(this))
            {
                RemoveSelfFromInventory();
            }
        }
    }
}
