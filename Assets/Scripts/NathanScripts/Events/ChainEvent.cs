using UnityEngine;
using System.Collections;
using System;

public class ChainEvent : IEvent
{
    [SerializeField] GameObject objectToActivate;
    [SerializeField] IEvent chainedEvent;

    bool shouldActivateChainEvents = true;

    public override void ActivateEvent()
    {
        if (dayChange)
        {
            EventDeck.DrawChosenEvent(chainedEvent);
        }
        else if (shouldActivateChainEvents)
        {
            objectToActivate.SetActive(true);
            ObserverSortOf.SubscribeNewIEvent(this);
        }
    }

    public void StopChain()
    {
        ObserverSortOf.UnSubscribeIEvent(this);
        shouldActivateChainEvents = false;
    }
}
