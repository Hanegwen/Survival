using UnityEngine;
using System.Collections.Generic;

public class FireEvent : IEvent
{
    [SerializeField] List<Room> RoomsToSetFireTo;
    [SerializeField] GameObject FireObject;

    public override void ActivateEvent()
    {
        foreach(Room room in RoomsToSetFireTo)
        {
            room.DestroyItemsInRoom();
            room.airQualityPercentage = 0.1f;
            //room.MakeRoomInaccessible();
        }

        FireObject.SetActive(true);
    }
}
