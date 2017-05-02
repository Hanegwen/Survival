using UnityEngine;
using System.Collections;
using System;

public class ChainEvent : IEvent
{
    [SerializeField] GameObject objectToActivate;
    [SerializeField] IEvent chainedEvent;

    public override void ActivateEvent()
    {
        if (dayChange)
        {
            EventDeck.DrawChosenEvent(chainedEvent);
        }
        else
        {
            objectToActivate.SetActive(true);
            ObserverSortOf.SubscribeNewIEvent(this);
        }
    }
}
