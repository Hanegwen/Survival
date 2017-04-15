using UnityEngine;
using System.Collections.Generic;

public class FireEvent : IEvent
{
    [SerializeField] List<Room> RoomsToSetFireTo;
    [SerializeField] List<Transform> FireSpawnLocations;
    [SerializeField] GameObject firePrefab;

    public override void ActivateEvent()
    {
        foreach(Room room in RoomsToSetFireTo)
        {
            room.DestroyItemsInRoom();
        }

        foreach(Transform spawnLocation in FireSpawnLocations)
        {
            Instantiate(firePrefab, spawnLocation.position, Quaternion.identity, spawnLocation);
        }
    }
}
