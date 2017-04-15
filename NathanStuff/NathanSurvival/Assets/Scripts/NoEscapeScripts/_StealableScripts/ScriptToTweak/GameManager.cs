using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    #region PlayerStuff
    [SerializeField]
    public float PlayerStartingHunger = 100;
    [SerializeField]
    public float PlayerHunger = 100;
    [SerializeField]
    GameObject PlayerObject;
    #endregion

    [SerializeField]
    GameObject ResetLocation;



  
    public void Start ()
    {
        PlayerObject.transform.position = ResetLocation.transform.position;

    }
    void Update ()
    {
        if (PlayerHunger > PlayerStartingHunger)
        {

            PlayerHunger = PlayerStartingHunger;
        }

    }

   public void DayReset()

    {
        PlayerHunger = PlayerStartingHunger;
        PlayerObject.transform.position = ResetLocation.transform.position;

    }

    void Awake()
    {
        Application.targetFrameRate = 120;
    }




}
