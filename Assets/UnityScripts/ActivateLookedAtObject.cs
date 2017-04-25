using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActivateLookedAtObject : MonoBehaviour
{
    //Script is meant to be put on the player Camera
    [SerializeField]
    Light flashlight;
    [SerializeField]
    float maxDistanceToActivate = 4;
    [SerializeField]
    LayerMask layerToCheckForObjects;
    [SerializeField]
    Text lookedAtObjectText;
    [SerializeField]
    Text lookedAtObjectText2;
    [SerializeField]
    GameObject inventoryManager;
    [SerializeField]
    InventoryManager inventoryManagerScript;
    IActivate lookedAtObject;

    public int currentInventoryItems = 0;
    public static bool shouldShowDisplayText = true;


    // Use this for initialization
    void Start()
    {
        lookedAtObjectText.gameObject.SetActive(false);
        lookedAtObjectText2.gameObject.SetActive(false);
        inventoryManager.GetComponent<InventoryManager>();


    }

    // Update is called once per frame
    void Update()
    {
        currentInventoryItems = inventoryManagerScript.InventoryObjects.Count;
        HandleInput();
        UpdateLookedAtObjectText();
        CheckForLookedAtObjects();
    }

    void HandleInput()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (lookedAtObject != null)
            {
                if (inventoryManagerScript.inventorySlots > currentInventoryItems)
                {
                    currentInventoryItems++;
                    lookedAtObject.DoActivate();
                    Debug.Log(currentInventoryItems.ToString());
                }
                else
                {
                    //To change the size of the inventory, look in the inventory manager script
                    Debug.Log("Inventory is full!");
                }
            }
        }
    }

    void UpdateLookedAtObjectText()
    {
        if (lookedAtObject == null || (shouldShowDisplayText == false && !flashlight.enabled))
        {
            lookedAtObjectText.gameObject.SetActive(false);
            lookedAtObjectText2.gameObject.SetActive(false);
        }
        else
        {
            lookedAtObjectText.text = lookedAtObject.NameText;
            lookedAtObjectText.gameObject.SetActive(true);
            lookedAtObjectText2.gameObject.SetActive(true);
        }
    }

    private void CheckForLookedAtObjects()
    {
        Vector3 endPoint = (transform.forward * maxDistanceToActivate) + transform.position;
        Debug.DrawLine(transform.position, endPoint, Color.red);

        RaycastHit rayCastHit;

        if (Physics.Raycast(transform.position, transform.forward, out rayCastHit, maxDistanceToActivate, layerToCheckForObjects))
        {
            lookedAtObject = rayCastHit.transform.gameObject.GetComponent<IActivate>();
        }
        else
        {
            lookedAtObject = null;
        }
    }


}
