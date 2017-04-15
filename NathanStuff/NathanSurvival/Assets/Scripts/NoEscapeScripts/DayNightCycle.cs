using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField]
    private GameObject SpawnLocationObject;
    [SerializeField]
    private GameObject PlayerObject;
    // Use this for initialization
    [SerializeField]
    GameObject Light;
    [SerializeField]
    private float xLocation = 0f;

    public bool isNightTime = false;

    [SerializeField]
    public float timeOfDay = 0;
    [SerializeField]
    private float ResetTime = 10000;

    private Vector3 lightorigin = new Vector3(0, 0, 0);


    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void FixedUpdate()
    {

        LightMovement();
        updateLocation();

    }

    void updateLocation()
    {

    }

    void LightMovement()
    {
        Light.transform.Rotate(Vector3.right * (Time.deltaTime ));


        timeOfDay++;

        if (timeOfDay > 8000)
        {
            isNightTime = true;
        }

        if (timeOfDay >= ResetTime) //and Don't have a torch
        {
            timeOfDay = 0;
            DayResetTimer();


        }
    }

    public void DayResetTimer()
    {
        PlayerObject.transform.position = SpawnLocationObject.transform.localPosition;
        timeOfDay = 0;
        Light.transform.rotation = Quaternion.identity;
        isNightTime = false;
    }



}
