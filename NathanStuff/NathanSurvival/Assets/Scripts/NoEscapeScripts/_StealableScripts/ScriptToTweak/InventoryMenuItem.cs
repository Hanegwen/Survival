using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class InventoryMenuItem : MonoBehaviour
{
    public Toggle toggle;
    private InventoryManager inventoryManager;

    public InventoryObject InventoryObjectRepresented { get; set; }

    public static InventoryMenuItem CurrentlySelectedItem;

    //public void ClickedThisMenuItem()
    //{
    //    AudioSource audio = inventoryManager.GetComponent<AudioSource>();
    //    //audio.Play();
    //}

    public void ClickedDropItem ()
    {

        
        
            InventoryObjectRepresented.DoDrop();
            
            inventoryManager.ShowInventoryMenu();
           


    }

    //TODO: Change this to allow this item to be used on another item or object in the scene
    public void ClickedUseItem()
    {
        //change the currently selected item to this item
        CurrentlySelectedItem = this;

        InventoryObjectRepresented.UseObject();
        
        inventoryManager.ShowInventoryMenu();
        



    }


    public void OnValueChanged()
    {
        if (toggle.isOn)
        {
            
            // update the description text based on the selected item
            inventoryManager.UpdateDescriptionText(InventoryObjectRepresented.DescriptionText);
        }

        
    }

    // Use this for initialization
    void Start()
    {
        toggle = GetComponent<Toggle>();
      
       

        try
        {
            inventoryManager = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>();
        }
        catch
        {
            throw new System.Exception("Scene requires game object" +
                " named \"Inventory Manager\" with an InventoryManager script attached");
        }
    }
}
