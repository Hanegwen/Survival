using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CaveInEvent : IEvent
{
    [SerializeField] GameObject rubble;
    [SerializeField] List<Room> roomsToLowerAirQualityIn;
    [SerializeField] AudioSource caveInAudio;
    [SerializeField] AudioClip[] sound;
    private void Start()
    {
        rubble.SetActive(false);
        caveInAudio.clip = sound[0];
    }

    public override void ActivateEvent()
    {
        rubble.SetActive(true);
        
        caveInAudio.Play();
        foreach(Room room in roomsToLowerAirQualityIn)
        {
            room.airQualityPercentage = 0.5f;
        }
    }
}
