using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EndSceneScript : MonoBehaviour {

    int pageNum = 1;

    [SerializeField]
    Text ButtonText;

    [SerializeField]
    Text Name1;

    [SerializeField]
    Text Name2;

    [SerializeField]
    Text Name3;

    [SerializeField]
    Text Description1;

    [SerializeField]
    Text Description2;

    [SerializeField]
    Text Description3;

    [SerializeField]
    Text Event1;

    [SerializeField]
    Text Event2;

    [SerializeField]
    Text Event3;



    [SerializeField]
    string PreventCaveIn;

    [SerializeField]
    string NotPreventCaveIn;

    [SerializeField]
    string PreventElectricalLeak;

    [SerializeField]
    string NotPreventElectricalLeak;

    [SerializeField]
    string PreventFire;

    [SerializeField]
    string NotPreventFire;

    

    List<IEvent> eventNames;
	// Use this for initialization
	void Start ()
    {
	
        eventNames = EventDeck.getActivatedEvents();

        CheckEvents();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void menuSystem()
    {
        if (pageNum == 3)
        {
            SceneManager.LoadScene("Credits");
        }

        if (pageNum == 2)
        {
            Name1.text = "Gas Leak";
            Description1.text = "When a major disaster strikes the piping in buildings can be damaged.  Keeping an eye out for sparking or dripping pipes.";
            Event1.text = "You made sure to stop a Gas Leak from happening.  Good job noticing the weak pipes and fixing them";

            Name2.text = "";
            Description2.text = "";
            Event2.text = "";

            Name3.text = "";
            Description3.text = "";
            Event3.text = "";

            pageNum++;

            ButtonText.text = "End Game";

            /*

       for (int x = 0; x < 7; x++)
       {
           

           if (eventNames[x] is GasLeakEvent) //Gas Leak Not In
           {
                Event1.text = "You let a Gas Leak happen.  Be careful next time to pay attention to pipes and secure any loose ones.";
           }
       }

   */
        }

        if (pageNum == 1)
        {
            Name1.text = "Flooding";
            Description1.text = "Flooding can happen after a major disaster.  Keep an eye out on water mains especially when you are in the basement of a building.";
            Event1.text = "You prevented a flood from happening.  Good job noticing the leaking pipes and fixing them.";
            

            Name2.text = "Pipe Leak";
            Description2.text = "When a major disaster strikes the piping in buildings can be damaged.  Keeping an eye out for sparking or dripping pipes.";
            Event2.text = "You stopped the water pipe from leaking.  Good job noticing it acting up and securing the pipe.";

            Name3.text = "Power Outage";
            Description3.text = "During a major disaster power lines can go down.  To be prepared make sure to have batteries and battery powered devices.  To go one step further have an emergency generator.";
            Event3.text = "Good Job preventing the Power from going out.  You noticed any electrical pipes leaking and stopped it. ";

            /* for (int x = 0; x < 7; x++)
             {



                 if (eventNames[x] is FloodEvent) //Flooding Not In
                 {
                     Event1.text = "You didn't stop the flood from happening.  Next time pay attention to leaking water and fix any pipes.";
                 }

                 if (eventNames[x] is PipeLeakEvent) //Pipe Leak Not In
                 {
                    Event2.text = "You didn't notice the Pipe Leaking on time.  Next time pay attention if it's dripping.";
                 }

                 if (eventNames[x] is GasLeakEvent) //Gas Leak Not In
                 {
                    Event3.text = "You didn't stop the Power from going out.  Next time tape or tighten any leaking electrical pipes.";
                 }
             } */

            pageNum++;
        }

        

        
    }
    void CheckEvents()
    {

        Event1.text = PreventCaveIn;
        Event2.text = PreventElectricalLeak;
        Event3.text = PreventFire;

       /* Flooding.text = PreventFlooding;
        GasLeak.text = PreventGasLeak;
        PipeLeak.text = PreventPipeLeak;
        PowerOutage.text = PreventPowerOutage; */

        /*

        for (int x = 0; x < 7; x++)
        {
            if (eventNames[x] is CaveInEvent) //Cave In
            {

            }

            if (eventNames[x] is PowerOutage) //Power Outage Not In
            {

            }

            if (eventNames[x] is FireEvent) //Fire
            {

            }

            if (eventNames[x] is ElectricalLeakEvent) //Electrical Leak Not In
            {

            }

            if (eventNames[x] is FloodEvent) //Flooding Not In
            {

            }

            if (eventNames[x] is PipeLeakEvent) //Pipe Leak Not In
            {

            }

            if (eventNames[x] is GasLeakEvent) //Gas Leak Not In
            {

            }
        }

    */
       
    }


}
