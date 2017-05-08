using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    Player player;
    [SerializeField]
    Slider healthSlider, FoodSlider, AirSlider, WaterSlider;

    void Start ()
    {
        player = FindObjectOfType<Player>();
        healthSlider.maxValue = player.health;
        FoodSlider.maxValue = player.hunger;
        WaterSlider.maxValue = player.thirst;
        
    }
    void Update ()
    {
        UpdatePlayerStats();

    }
    void UpdatePlayerStats ()
    {
        #region HealthSlider
        healthSlider.value = player.health;

        #endregion

        #region FoodSlider
        FoodSlider.value = player.hunger;

        #endregion

        #region WaterSlider

        WaterSlider.value = player.thirst;
        #endregion

        #region AirSlider


        #endregion


    }

}
