using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IPointerDownHandler
{
    InventoryManager IM;
    GameObject thisObject;

    public bool wasSelected;

    void Start ()
    {
        IM = GetComponent<InventoryManager>();
        thisObject = this.gameObject;

    }

    void Update ()
    {
        UpdateCurrentSelected();

    }


    public void OnPointerDown(PointerEventData eventData)
    {
        wasSelected = true;


    }

    void UpdateCurrentSelected ()
    {
        if (wasSelected == true)
        {

            //IM.currentlySelected = thisObject;
        }

    }
   
}
