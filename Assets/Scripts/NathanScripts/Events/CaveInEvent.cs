using UnityEngine;
using System.Collections;
using System;

public class CaveInEvent : IEvent
{
    [SerializeField] GameObject rubble;

    private void Start()
    {
        rubble.SetActive(false);
    }

    public override void ActivateEvent()
    {
        rubble.SetActive(true);
    }
}
