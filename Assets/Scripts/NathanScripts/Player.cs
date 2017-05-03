using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    string LooseText = "You couldn't last long enough to be rescued.  The world slowly blacks out.  You must rest now until someone comes to get you. ";
    [SerializeField]
    Text EndScreen;
    [SerializeField]
    GameObject WinLoseScreenPanel;

    [SerializeField]
    Light flashlight;

    [SerializeField]
    float breathingDecayRate = 5;

    [SerializeField]
    float hungerDecayRate = 1;

    [SerializeField]
    float thirstDecayRate = 1;

    [SerializeField]
    float healthDecayRate = 1;

    [SerializeField]
    float restroomDecayRate = 1;

    [SerializeField]
    float energyDecayRate = 1;

    public Room currentRoom;
    DustMask dustMaskSlot = null;

    //public float condition = 100f;
    public float thirst = 100f;
    public float hunger = 100f;
    public float health = 100f;
    public float restroom = 100f;
    public float breathing = 100f;
    public float energy = 100f;

    public int numberOfWounds = 0;


    void Start()
    {

    }

    public void SetCurrentRoom(Room desiredRoom)
    {
        currentRoom = desiredRoom;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    TurnOnOffFlashlight();
        //}

        UpdateStats();
        CheckIfPlayerIsIncapacitated();
    }

    void UpdateStats()
    {
        //decay breathing based on a percentage of the room's air quality (if we don't have a dust mask on)
        if (dustMaskSlot == null)
        {
            breathing -= (1 - currentRoom.airQualityPercentage) * breathingDecayRate * Time.deltaTime;
        }

        //decrease hunger and thirst by their decay rates
        hunger -= hungerDecayRate * Time.deltaTime;
        thirst -= thirstDecayRate * Time.deltaTime;

        if(restroom <= 0)
        {
            restroom = 0;
            health -= restroomDecayRate * Time.deltaTime;
        }
        else
        {
            restroom -= restroomDecayRate * Time.deltaTime;
        }

        if(energy <= 0)
        {
            energy = 0;
            health -= energyDecayRate * Time.deltaTime;
        }
        else
        {
            energy -= energyDecayRate * Time.deltaTime;
        }
    }

    void CheckIfPlayerIsIncapacitated()
    {
        if (/*condition <= 0 ||*/ thirst <= 0 || hunger <= 0 || health <= 0 || breathing <= 0)
        {
            //Debug.Log("Player is now incapacitated");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            EndScreen.text = LooseText;
            WinLoseScreenPanel.SetActive(true);
            
        }
    }

    public bool EquipDustMask(DustMask dustMaskToEquip)
    {
        if (dustMaskSlot == null)
        {
            dustMaskSlot = dustMaskToEquip;
            return true;
        }
        else
        {
            Debug.Log("Display prompt: \"You already have a dust mask equipped!\"");
            return true;
        }
    }
}
