using UnityEngine;
using System.Collections;

public class Whistle : InventoryObj
{
    DayCycle dayCycleScript;
    [SerializeField] int daysUntilRescueWhenWhistleIsEffective = 1;

    string[] whistleMessages;
    InventoryManager IM;
    void Start()
    {
        itemType = ItemType.TOOL;
        IM = FindObjectOfType<InventoryManager>();
        whistleMessages = new string[] {
            "You try to blow the whistle.  The storm is still raging, so chances are, no one heard you.",
            "You try to blow the whistle.  The storm is still raging, so chances are, no one heard you.",
            "You blow as loud as you can using the whistle.  You hope someone can hear you.",
            "You blow as loud as you can using the whistle.  You hope someone can hear you.",
            "You blow as loud as you can using the whistle.  You hope someone can hear you.",
            "You hope search parties are nearby.  you blow the whistle for what seems like the last time.",
            "You hope search parties are nearby.  you blow the whistle for what seems like the last time."
        };

        dayCycleScript = FindObjectOfType<DayCycle>();
        if(!dayCycleScript)
        {
            throw new System.Exception("There is no gameObject with a \"DayCycle\" scipt attached");
        }

    }

    public override void UseItemOn(InventoryObj itemToUseOn)
    {
        if(!itemToUseOn)
        {
            //if the search parties are close enough
            if (dayCycleScript.DaysUntilRescue <= daysUntilRescueWhenWhistleIsEffective)
            {
                IM.DialogPanel.SetActive(true);
                IM.DialogText.text = whistleMessages[dayCycleScript.currentDay];
                dayCycleScript.RescueDay--;
                IM.ShowInventoryMenu();
            }
        }
    }
}
