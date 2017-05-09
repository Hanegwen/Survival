using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static bool isGameOver = false;
    string LooseText = "You couldn't last long enough to be rescued.  The world slowly blacks out.  You must rest now until someone comes to get you. ";
    [SerializeField]
    Text EndScreen;
    [SerializeField]
    GameObject WinLoseScreenPanel;
    InventoryManager IM;
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

    //[SerializeField]
    //float restroomDecayRate = 1;

    //[SerializeField]
    //float energyDecayRate = 1;

    public Room currentRoom;
    DustMask dustMaskSlot = null;

    #region player stat properties and variables

    //public float condition = 100f;
    [SerializeField] float thirst = 10f;
    [SerializeField] float hunger = 10f;
    [SerializeField] float health = 10f;
    [SerializeField] float breathing = 10f;

    float maxThirst;
    float maxHunger;
    float maxHealth;
    float maxBreathing;

    //public float restroom = 100f;
    //public float energy = 100f;

    public float Thirst
    {
        get { return thirst; }
        set
        {
            thirst = value;

            if (value > 0 && thirst > maxThirst)
                thirst = maxThirst;
        }
    }

    public float Hunger
    {
        get { return hunger; }
        set
        {
            hunger = value;

            if (value > 0 && hunger > maxHunger)
                hunger = maxHunger;
        }
    }


    public float Breathing
    {
        get { return breathing; }
        set
        {
            breathing = value;

            if (value > 0 && breathing > maxBreathing)
                breathing = maxBreathing;
        }
    }

    public float Health
    {
        get { return health; }
        set
        {
            health = value;

            if (value > 0 && health > maxHealth)
                health = maxHealth;
        }
    }
    #endregion

    //public int numberOfWounds = 0;


    void Start()
    {
        maxThirst = thirst;
        maxHealth = health;
        maxHunger = hunger;
        maxBreathing = breathing;
        IM = FindObjectOfType<InventoryManager>();
    }

    public void SetCurrentRoom(Room desiredRoom)
    {
        currentRoom = desiredRoom;
    }

    private void Update()
    {
        UpdateStats();
        CheckIfPlayerIsIncapacitated();
    }

    void UpdateStats()
    {
        //decay breathing based on a percentage of the room's air quality (if we don't have a dust mask on)
        if (dustMaskSlot == null)
        {
            Breathing -= (1 - currentRoom.airQualityPercentage) * breathingDecayRate * Time.deltaTime;
        }

        //decrease hunger and thirst by their decay rates
        Hunger -= hungerDecayRate * Time.deltaTime;
        Thirst -= thirstDecayRate * Time.deltaTime;

        //if(restroom <= 0)
        //{
        //    restroom = 0;
        //    health -= restroomDecayRate * Time.deltaTime;
        //}
        //else
        //{
        //    restroom -= restroomDecayRate * Time.deltaTime;
        //}

        //if(energy <= 0)
        //{
        //    energy = 0;
        //    health -= energyDecayRate * Time.deltaTime;
        //}
        //else
        //{
        //    energy -= energyDecayRate * Time.deltaTime;
        //}
    }

    void CheckIfPlayerIsIncapacitated()
    {
        if (/*condition <= 0 ||*/ thirst <= 0 || hunger <= 0 || health <= 0 || breathing <= 0)
        {
            isGameOver = true;
            gameObject.GetComponent<CharacterController>().enabled = false;
            this.enabled = false;
            IM.UpdateCursor();
            //Debug.Log("Player is now incapacitated");

            EndScreen.text = LooseText;
            WinLoseScreenPanel.SetActive(true);
            IM.gameOver = true;
            
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
