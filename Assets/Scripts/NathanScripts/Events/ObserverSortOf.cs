using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObserverSortOf : MonoBehaviour
{
    static List<IEvent> listeningEvents = new List<IEvent>();

    public static void SubscribeNewIEvent(IEvent eventToSubscribe)
    {
        listeningEvents.Add(eventToSubscribe);
    }

    public static void AlertDayChange()
    {
        for(int x = listeningEvents.Count - 1; x >= 0; x--)
        {
            listeningEvents[x].dayChange = true;
            listeningEvents[x].ActivateEvent();
            listeningEvents.Remove(listeningEvents[x]);
        }
    }
}
