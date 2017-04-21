using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class InventoryObj : MonoBehaviour, IActivate
{
   // private GameManager GM;
    [SerializeField]
    string nameText;

    [SerializeField]
    string descriptionText;

    [SerializeField]
    Sprite mainImage;

    InventoryManager inventoryManager;
    ActivateLookedAtObject activateLookedAtObject;
    bool shouldDisableWhenDonePlayingSFX = false;
    AudioSource audioSource;
    MeshRenderer childMesh;
    BoxCollider childCollider;
  //  GrenadeScript grenadeScript;


    public string NameText
    {
        get
        {
            return nameText;
        }
    }

    public string DescriptionText
    {
        get
        {
            return descriptionText;
        }
    }

    public Sprite MainImage //Set as Image for the UI Part 
    {
        get
        {
            return mainImage;
        }

    }



    public void DoActivate()
    {

        Debug.Log("Activated.");

        audioSource.Play();
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
        //MeshRenderer childMesh = GetComponentInChildren<MeshRenderer>();
       // childMesh.enabled = false;
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        //BoxCollider childCollider = GetComponentInChildren<BoxCollider>();
        //childCollider.enabled = false;
        boxCollider.enabled = false;

        shouldDisableWhenDonePlayingSFX = true;
        if (shouldDisableWhenDonePlayingSFX && !audioSource.isPlaying)
        {
            //gameObject.SetActive(false);
            inventoryManager.InventoryObjects.Add(this);
        }

    }

    public void DoDrop()
    {

        inventoryManager.InventoryObjects.Remove(this);
        Debug.Log("Dropped");
        Debug.Log(this.nameText);

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = true;

        childMesh.enabled = true;
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = true;

        childCollider.enabled = true;

        this.transform.position = inventoryManager.Player.transform.position;

        shouldDisableWhenDonePlayingSFX = true;

    }

    public void DoEat()
    {



    }


    // Use this for initialization
    void Start()
    {
       
        
        childCollider = GetComponentInChildren<BoxCollider>();
        childMesh = GetComponentInChildren<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
        try
        {
            inventoryManager = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>();
        }
        catch (Exception)
        {
            throw new System.Exception("Scene must contain a gameobject named 'Inventory Manager'" +
                     " with an InventoryManager script attached.");
        }
    }

    void Update()
    {

    }

}
