using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField]
    Light flashlight;

    [SerializeField]
    float breathingDecayRate;

    [SerializeField]
    float hungerDecayRate;

    [SerializeField]
    float thirstDecayRate;

    [SerializeField]
    float healthDecayRate;

    public Room currentRoom;

    float condition = 100f;
    float thirst = 100f;
    float hunger = 100f;
    float health = 100f;
    public float breathing = 100f;

    public void SetCurrentRoom(Room desiredRoom)
    {
        currentRoom = desiredRoom;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashlight.enabled)
            {
                flashlight.enabled = false;
            }
            else
            {
                flashlight.enabled = true;
            }
        }

        UpdateStats();
        CheckIfPlayerIsIncapacitated();
    }

    void UpdateStats()
    {
        //decay breathing based on a percentage of the room's air quality
        breathing -= (1 - currentRoom.airQualityPercentage) * breathingDecayRate * Time.deltaTime;

        //decrease hunger and thirst by their decay rates
        hunger -= hungerDecayRate * Time.deltaTime;
        thirst -= thirstDecayRate * Time.deltaTime;
    }

    void CheckIfPlayerIsIncapacitated()
    {
        if (condition <= 0 || thirst <= 0 || hunger <= 0 || health <= 0 || breathing <= 0)
        {
            Debug.Log("Player is now incapacitated");
        }
    }
}
