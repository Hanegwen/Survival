using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class EndSceneScript : MonoBehaviour {

    [SerializeField]
    Text CaveIn;

    [SerializeField]
    Text ElectricalLeak;

    [SerializeField]
    Text Fire;

    [SerializeField]
    Text Flooding;

    [SerializeField]
    Text GasLeak;

    [SerializeField]
    Text PipeLeak;

    [SerializeField]
    Text PowerOutage;

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

    [SerializeField]
    string PreventFlooding;

    [SerializeField]
    string NotPreventFlooding;

    [SerializeField]
    string PreventGasLeak;

    [SerializeField]
    string NotPreventGasLeak;

    [SerializeField]
    string PreventPipeLeak;

    [SerializeField]
    string NotPreventPipeLeak;

    [SerializeField]
    string PreventPowerOutage;

    [SerializeField]
    string NotPreventPowerOutage;

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

    void CheckEvents()
    {

        CaveIn.text = PreventCaveIn;
        ElectricalLeak.text = PreventElectricalLeak;
        Fire.text = PreventFire;
        Flooding.text = PreventFlooding;
        GasLeak.text = PreventGasLeak;
        PipeLeak.text = PreventPipeLeak;
        PowerOutage.text = PreventPowerOutage;

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
