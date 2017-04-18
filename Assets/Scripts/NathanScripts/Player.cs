using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] Light flashlight;

    public Room currentRoom;

    float condition;
    float thirst;
    float hunger;
    float health;
    float breathing;

    public void SetCurrentRoom(Room desiredRoom)
    {
        currentRoom = desiredRoom;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(flashlight.enabled)
            {
                flashlight.enabled = false;
            }
            else
            {
                flashlight.enabled = true;
            }
        }
    }
}
