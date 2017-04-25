using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EventDeck : MonoBehaviour
{
    static List<IEvent> allEvents;                  //ALL of the events
    static List<IEvent> eventList;                  //Events that have NOT been triggered yet
    static List<IEvent> alreadyTriggeredEvents;     //Events that have already triggered

	// Use this for initialization
	void Start ()
    {
        alreadyTriggeredEvents = new List<IEvent>();   //This list should start empty
        allEvents = FindObjectsOfType<IEvent>().ToList();
        eventList = allEvents;
	}

    public static void DrawRandomNewEvent()
    {
        //draw a random event and activate it
        int randomEventIndex = Random.Range(0, eventList.Count);
        IEvent chosenEvent = eventList[randomEventIndex];
        chosenEvent.ActivateEvent();

        //move the event from the untriggered event list to the triggered one
        eventList.Remove(chosenEvent);
        alreadyTriggeredEvents.Add(chosenEvent);
    }

    public static void DrawChosenEvent(IEvent eventToDraw)
    {
        eventToDraw.ActivateEvent();

        if(eventList.Contains(eventToDraw))
        {
            //move the event from the untriggered event list to the triggered one
            eventList.Remove(eventToDraw);
            alreadyTriggeredEvents.Add(eventToDraw);
        }
    }

    public static List<IEvent> getActivatedEvents()
    {
        return alreadyTriggeredEvents;
    }
}
