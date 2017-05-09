using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Radio : InventoryObj
{
    string[] radioMessages;
    DayCycle dayCycleScript;
    InventoryManager IM;


    int dialogNum = 0;
    void Start()
    {
        IM = FindObjectOfType<InventoryManager>();
        itemType = ItemType.TOOL;

        radioMessages = new string[] {
            "You turn the radio on and it's very staticy.  All you can make out is \"Major hurricane in process...... shelter\".",
            "You check the radio, it seems to be working more like normal.  All you can find is a non-local station talking about how bad the hurricane is.",
            "You find a news station: \"The Hurricane has finally passed.  Rescuers are now starting the process of finding people\".",
            "You find a local station talking about the rescue effort: \"Rescuers are working 24/7 trying to find people, more when we come back from break\" and the signal is lost.",
            "You turn on the radio and this message instantly happens: \"Looks like only a few people are still missing from the local college.  Hopefully the rescuers can find them before it's too late. According to what most of the dorms had, they are running out of time\"",
            "You turn on the radio and this message instantly happens: \"Looks like only a few people are still missing from the local college.  Hopefully the rescuers can find them before it's too late. According to what most of the dorms had, they are running out of time\""
        };

        dayCycleScript = FindObjectOfType<DayCycle>();
        if (!dayCycleScript)
        {
            throw new System.Exception("There is no gameObject with a \"DayCycle\" scipt attached");
        }
    }

    public override void UseItemOn(InventoryObj itemToUseOn)
    {
        if(!itemToUseOn)
        {
            updateText();
        }
    }

    public void  updateText ()
    {
        IM.DialogPanel.SetActive(true);
        IM.DialogText.text = radioMessages[dayCycleScript.currentDay];      
         IM.ShowInventoryMenu(); 

    }

    //public void NextButtonPressed ()
    //{
    //    if (dialogNum < radioMessages.Length)
    //    {
    //        dialogNum++;
    //    }
    //}

    //public void BackButtonPressed()
    //{
    //    if (dialogNum < 0)
    //    {
    //        dialogNum--;
    //    }

    //    else
    //        return;
    //}
}
