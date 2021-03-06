﻿using UnityEngine;
using System.Collections.Generic;

public class FireEvent : IEvent
{
    [SerializeField] List<Room> RoomsToSetFireTo;
    [SerializeField] GameObject FireObject;
    [SerializeField] AudioSource FireSound;
    [SerializeField] AudioClip FireClip;
    int firesLeft = 4;

    public override void ActivateEvent()
    {
        foreach(Room room in RoomsToSetFireTo)
        {
            room.DestroyItemsInRoom();
            room.airQualityPercentage = 0.1f;
            //room.MakeRoomInaccessible();
        }


        FireObject.SetActive(true);
        FireSound.clip = FireClip;
        FireSound.Play();
    }

    public void PutOutFire(GameObject fire)
    {
        //deactivate that fire
        fire.SetActive(false);
        FireSound.clip = null;
        firesLeft--;

        //if we've put out all the fires...
        if(firesLeft <= 0)
        {
            //make the air quality normal in each room and deactivate this event
            foreach(Room room in RoomsToSetFireTo)
            {
                room.airQualityPercentage = 1f;
            }

            this.gameObject.SetActive(false);
        }
    }
}
