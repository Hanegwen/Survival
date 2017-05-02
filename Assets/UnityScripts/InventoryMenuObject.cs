using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Toggle))]
public class InventoryMenuObject : MonoBehaviour , ISelectHandler
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
        inventoryManager.ShowInventoryMenu();
    }

    public void OnSelect(BaseEventData eventData)
    {
        
        inventoryManager.ToggleCount++;
        Debug.Log(inventoryManager.ToggleCount + "Toggle Count");
       
        inventoryManager.UpdateDescriptionText(InventoryObjectRepresented.DescriptionText);

        if (inventoryManager.FirstSelected == null)
        {
            inventoryManager.FirstSelected = InventoryObjectRepresented.gameObject;
            inventoryManager.FirstImage.sprite = inventoryManager.FirstSelected.gameObject.GetComponent<InventoryObj>().MainImage;
            inventoryManager.FirstSelectedObject = inventoryManager.FirstSelected.gameObject.GetComponent<InventoryObj>();
        }

        if (inventoryManager.FirstSelected !=null && inventoryManager.SecondSelected == null && InventoryObjectRepresented.gameObject != inventoryManager.FirstSelected)
        {
            inventoryManager.SecondSelected = InventoryObjectRepresented.gameObject;

            inventoryManager.SecondImage.sprite = inventoryManager.SecondSelected.gameObject.GetComponent<InventoryObj>().MainImage;
            inventoryManager.SecondSelectedObject = inventoryManager.SecondSelected.gameObject.GetComponent<InventoryObj>();

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

