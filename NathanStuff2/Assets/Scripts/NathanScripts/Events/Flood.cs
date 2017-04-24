using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Flood : IEvent
{
    [SerializeField] List<Room> RoomsToFlood;
    [SerializeField] GameObject FloodObject;

    public override void ActivateEvent()
    {
        foreach (Room room in RoomsToFlood)
        {
            room.DestroyItemsInRoom(InventoryObj.ItemType.ELECTRIC);
            room.MakeRoomInaccessible();
        }

        FloodObject.SetActive(true);
    }
}
