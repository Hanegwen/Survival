using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class InventoryMenuObject : MonoBehaviour
{
    //private GameManager GM;

    public Toggle toggle;
    private InventoryManager inventoryManager;

    public InventoryObj InventoryObjectRepresented { get; set; }



    public void ClickedThisMenuItem()
    {
        AudioSource audio = inventoryManager.GetComponent<AudioSource>();
        //audio.Play();
    }

    public void ClickedDropItem()
    {



        InventoryObjectRepresented.DoDrop();

        inventoryManager.ShowInventoryMenu();



    }
    public void ClickedEat()
    {

        InventoryObjectRepresented.DoEat();

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

    // Update is called once per frame
    void Update()
    {

    }
}

