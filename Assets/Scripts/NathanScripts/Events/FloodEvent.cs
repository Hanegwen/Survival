﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloodEvent : IEvent
{
    [SerializeField] List<Room> RoomsToFlood;
    [SerializeField] GameObject FloodObject;
    [SerializeField] AudioSource FloodAudio;
    [SerializeField] AudioClip FloodClip;

    public override void ActivateEvent()
    {
        foreach (Room room in RoomsToFlood)
        {
            room.DestroyItemsInRoom(InventoryObj.ItemType.ELECTRIC);
            //room.MakeRoomInaccessible();
        }

        FloodObject.SetActive(true);
        FloodAudio.clip = FloodClip;
        FloodAudio.Play();
    }
}
