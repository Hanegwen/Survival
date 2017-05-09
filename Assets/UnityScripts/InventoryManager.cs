using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Toggle toggle;
    [SerializeField]
    GameObject inventoryMenuPanel;

    public GameObject inventoryObjectToggle;

    [SerializeField]
    public GameObject FirstSelected, SecondSelected;

    [SerializeField]
    FirstPersonController firstPersonController;

    [SerializeField]
    GameObject inventoryItemTogglePrefab;

    [SerializeField]
    Transform inventoryItemsListPanel;

    [SerializeField]
    Text descriptionText, numberOfInventoryItems;

    [SerializeField]
    public Image FirstImage, SecondImage;
    [HideInInspector] public InventoryObj FirstSelectedObject, SecondSelectedObject;

    [SerializeField] Sprite Default;

    [SerializeField]
    public GameObject Player;

    ActivateLookedAtObject activateLookedAtObject;

    public int ToggleCount;


    public List<InventoryObj> InventoryObjects { get; set; }

    private List<GameObject> inventoryObjectImage;

    public const string DefaultDescriptionMessage =
        "If you've picked anything up, you can select it to learn more." +
        "\n\nIf you haven't, you'll just have to close the menu and keep playing...";

    public bool isInventoryMenuShowing;

    //CHANGE THIS VALUE TO INCREASE OR DECREASE THE SIZE OF THE PLAYER'S INVENTORY
    public int inventorySlots = 5;


    // Use this for initialization
    void Start()
    {
        
        InventoryObjects = new List<InventoryObj>();
        inventoryObjectImage = new List<GameObject>();
        HideInventoryMenu();
        UpdateDescriptionText(DefaultDescriptionMessage);

        Flashlight playerFlashlight = FindObjectOfType<Flashlight>();
        InventoryObjects.Add(playerFlashlight);

    }

    // Update is called once per frame
    void Update()
    {

        HandleInput();
        UpdateCursor();
        UpdateFirstPersonController();
        if (ToggleCount > 2)
        {

            ShowInventoryMenu();
            ToggleCount = 0;

        }

    }

    public void UpdateDescriptionText(string newText)
    {
        descriptionText.text = newText;
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (isInventoryMenuShowing)
            {
                HideInventoryMenu();
            }
            else
            {
                ShowInventoryMenu();
            }
        }
    }

    public void ShowInventoryMenu()
    {
        FirstSelected = null;
        SecondSelected = null;
        FirstSelectedObject = null;
        SecondSelectedObject = null;
        UpdateUIImage();
        ToggleCount = 0;
        DestroyInventoryItemToggles();
        GenerateInventoryItemToggles();
        isInventoryMenuShowing = true;
        inventoryMenuPanel.SetActive(true);
        numberOfInventoryItems.text = InventoryObjects.Count.ToString() + "/" + inventorySlots;
    }
    public void ResetInventory () // called to reset Inventory when not showing
    {
        FirstSelected = null;
        SecondSelected = null;
        FirstSelectedObject = null;
        SecondSelectedObject = null;
        UpdateUIImage();
        ToggleCount = 0;
        DestroyInventoryItemToggles();
        GenerateInventoryItemToggles();
        isInventoryMenuShowing = false;
        inventoryMenuPanel.SetActive(false);
        numberOfInventoryItems.text = InventoryObjects.Count.ToString() + "/" + inventorySlots;

    }

    private void DestroyInventoryItemToggles()
    {
        foreach (GameObject item in inventoryObjectImage)
        {
            Destroy(item);
        }
    }

    private void GenerateInventoryItemToggles()
    {

        for (int i = 0; i < InventoryObjects.Count; i++)
        {

            if (inventorySlots > i)
            {

                inventoryObjectToggle =
                    GameObject.Instantiate(inventoryItemTogglePrefab, inventoryItemsListPanel) as GameObject;

                inventoryObjectToggle.GetComponent<InventoryMenuObject>().InventoryObjectRepresented =
                    InventoryObjects[i];

                inventoryObjectToggle.GetComponentInChildren<Text>().text =
                    InventoryObjects[i].NameText;
                inventoryObjectToggle.GetComponentInChildren<Image>(gameObject.name == "Background").sprite =
                     InventoryObjects[i].MainImage; // Sets the Image in toggle


                inventoryObjectToggle.tag = InventoryObjects[i].tag;

                 toggle = inventoryObjectToggle.GetComponent<Toggle>();
                toggle.group = inventoryItemsListPanel.GetComponent<ToggleGroup>();
                
                inventoryObjectImage.Add(inventoryObjectToggle);
            }
        }
    }

    public void HideInventoryMenu()
    {
        isInventoryMenuShowing = false;
        inventoryMenuPanel.SetActive(false);

    }

    private void UpdateFirstPersonController()
    {
        if (isInventoryMenuShowing)
        {
            firstPersonController.enabled = false;
        }
        else
        {
            firstPersonController.enabled = true;
        }
    }

    public void UpdateCursor()
    {
        if (isInventoryMenuShowing)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }


    void UpdateUIImage ()
    {
        FirstImage.sprite = Default;
        SecondImage.sprite = Default;

    }


    public void UseItemsOnEachOther()
    {
        if(FirstSelectedObject) //if a first object is selected
        {
            if(SecondSelectedObject) //if a second object is selected, use the first item on the second item
            {
                SecondSelectedObject.UseItemOn(FirstSelectedObject);
            }
            else //otherwise, we'll use the items on the player
            {
                FirstSelectedObject.UseItemOn(null);
            }
        }
    }


}

