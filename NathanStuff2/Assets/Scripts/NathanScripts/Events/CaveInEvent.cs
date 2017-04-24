using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CaveInEvent : IEvent
{
    [SerializeField] GameObject rubble;
    [SerializeField] List<Room> roomsToLowerAirQualityIn;

    private void Start()
    {
        rubble.SetActive(false);
    }

    public override void ActivateEvent()
    {
        rubble.SetActive(true);

        foreach(Room room in roomsToLowerAirQualityIn)
        {
            room.airQualityPercentage = 0.5f;
        }
    }
}
