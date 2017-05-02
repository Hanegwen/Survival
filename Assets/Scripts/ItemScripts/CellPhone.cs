using UnityEngine;
using System.Collections;

public class CellPhone : InventoryObj
{
    DayCycle dayCycleScript;
    [SerializeField] int daysUntilPhoneIsEffective = 1;

    string[] CellPhoneMessages;

    [SerializeField] float batteryChargeStart = 100f;
    [SerializeField] float batteryChargeConsumerPerUse = 33f;
    float batteryCharge;

    bool hasAlreadyCalledRescue;

    void Start()
    {
        itemType = ItemType.ELECTRIC;

        CellPhoneMessages = new string[] {
            "There is no phone signal.  The towers must be down.",
            "You are still getting no signal on the phone.  Better not waste the battery!",
            "You're getting a weak signal.  Unfortunately, the quality isn't good enough to call.",
            "You're getting a weak signal.  The only thing that truly works is the alarm network.  A message reads \"Resucers are in your area.\" as well as a number to contact them.  You call.  The signal is choppy, but you get a hold of them!",
            "More service is coming back to the phone.  You try calling for help, and someone picks up.  The line is clear.  You give them your status and general location, but they warn you there's many others in need as well.",
            "You call for help, someone picks up, and you give them your status and general location.  They tell you they'll be there as quickly as possible.",
            "You call for help, someone picks up, and you give them your status and general location.  They tell you they'll be there as quickly as possible."
        };

        dayCycleScript = FindObjectOfType<DayCycle>();
        if (!dayCycleScript)
        {
            throw new System.Exception("There is no gameObject with a \"DayCycle\" scipt attached");
        }

    }

    public override void UseItemOn(InventoryObj itemToUseOn)
    {
        if (!itemToUseOn)
        {
            if (dayCycleScript.currentDay <= daysUntilPhoneIsEffective)
            {
                Debug.Log("Display Prompt: " + CellPhoneMessages[dayCycleScript.currentDay]);

                if (hasAlreadyCalledRescue)
                {
                    Debug.Log("Display Prompt: \"Resuce is already on the way.  You can't speed up the process anymore.\"");
                }
                else
                {
                    dayCycleScript.RescueDay--;
                }

                hasAlreadyCalledRescue = true;
            }

            batteryCharge -= batteryChargeConsumerPerUse;
        }
        else if (itemToUseOn is Batteries)
        {
            batteryCharge = batteryChargeStart;
            itemToUseOn.RemoveSelfFromInventory();
        }
    }
}
