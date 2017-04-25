using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DayCycle : MonoBehaviour
{
    [SerializeField] float LengthPerDayInSeconds;
    [SerializeField] Slider daySlider;

    float dayCountdown;
    int currentDay;

    public int DaysUntilResuce;

	// Use this for initialization
	void Start ()
    {
        dayCountdown = LengthPerDayInSeconds;
        //daySlider.maxValue = LengthPerDayInSeconds;
	}
	
	// Update is called once per frame
	void Update ()
    {
        dayCountdown -= Time.deltaTime;

        if (dayCountdown <= 0)
        {
            EventDeck.DrawNewRandomNewEvent();

            currentDay++;
            dayCountdown = LengthPerDayInSeconds;

            if (currentDay >= DaysUntilResuce)
                Rescue();
        }

        //daySlider.value = dayCountdown;
	}

    void Rescue()
    {
        //You "won" the game!
    }
}
