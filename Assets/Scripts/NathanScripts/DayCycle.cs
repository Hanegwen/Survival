using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DayCycle : MonoBehaviour
{
    string WinText = "You lasted long enough to be rescued!";
    [SerializeField]
    Text EndScreen;
    [SerializeField]
    GameObject WinLoseScreenPanel;

    [SerializeField]
    float LengthPerDayInSeconds;
    //[SerializeField] Slider daySlider;

    float dayCountdown;
    public int currentDay = 0;

    public int RescueDay;

    public int DaysUntilRescue
    { get { return RescueDay - currentDay; } }

    // Use this for initialization
    void Start()
    {
        dayCountdown = LengthPerDayInSeconds;
        //daySlider.maxValue = LengthPerDayInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        dayCountdown -= Time.deltaTime;

        if (dayCountdown <= 0)
        {
            Debug.Log("Next Day");
            currentDay++;

            if (currentDay >= RescueDay)
                Rescue();

            dayCountdown = LengthPerDayInSeconds;
            ObserverSortOf.AlertDayChange();
            EventDeck.DrawRandomNewEvent();
        }

        //daySlider.value = dayCountdown;
    }

    void Rescue()
    {
        //You "won" the game!
        EndScreen.text = WinText;
        WinLoseScreenPanel.SetActive(true);
    }
}
