using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    GameObject inventoryMenuPanel;

    [SerializeField]
    FirstPersonController firstPersonController;

    [SerializeField]
    GameObject inventoryItemTogglePrefab;

    [SerializeField]
    Transform inventoryItemsListPanel;

    [SerializeField]
    Text descriptionText;

    [SerializeField]
    public GameObject Player;

    ActivateLookedAtObject activateLookedAtObject;



    public List<InventoryObj> InventoryObjects { get; set; }

    private List<GameObject> inventoryObjectToggles;

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
        inventoryObjectToggles = new List<GameObject>();
        HideInventoryMenu();
        UpdateDescriptionText(DefaultDescriptionMessage);

    }

    // Update is called once per frame
    void Update()
    {

        HandleInput();
        UpdateCursor();
        UpdateFirstPersonController();
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
        DestroyInventoryItemToggles();
        GenerateInventoryItemToggles();
        isInventoryMenuShowing = true;
        inventoryMenuPanel.SetActive(true);
    }

    private void DestroyInventoryItemToggles()
    {
        foreach (GameObject item in inventoryObjectToggles)
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

                GameObject inventoryObjectToggle =
                    GameObject.Instantiate(inventoryItemTogglePrefab, inventoryItemsListPanel) as GameObject;

                inventoryObjectToggle.GetComponent<InventoryMenuObject>().InventoryObjectRepresented =
                    InventoryObjects[i];

                inventoryObjectToggle.GetComponentInChildren<Text>().text =
                    InventoryObjects[i].NameText;
                inventoryObjectToggle.tag = InventoryObjects[i].tag;

                Toggle toggle = inventoryObjectToggle.GetComponent<Toggle>();
                toggle.group = inventoryItemsListPanel.GetComponent<ToggleGroup>();

                inventoryObjectToggles.Add(inventoryObjectToggle);
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

    private void UpdateCursor()
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
}

