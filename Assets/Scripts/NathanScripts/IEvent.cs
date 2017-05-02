using UnityEngine;
using System.Collections;

public abstract class IEvent : MonoBehaviour
{
    [HideInInspector] public bool dayChange = false;
    public bool shouldDrawAtRandom = true;
    public abstract void ActivateEvent();
}
