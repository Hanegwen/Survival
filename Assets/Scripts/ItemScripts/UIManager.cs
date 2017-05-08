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
        healthSlider.maxValue = player.Health;
        FoodSlider.maxValue = player.Hunger;
        WaterSlider.maxValue = player.Thirst;
        
    }
    void Update ()
    {
        UpdatePlayerStats();

    }
    void UpdatePlayerStats ()
    {
        #region HealthSlider
        healthSlider.value = player.Health;

        #endregion

        #region FoodSlider
        FoodSlider.value = player.Hunger;

        #endregion

        #region WaterSlider

        WaterSlider.value = player.Thirst;
        #endregion

        #region AirSlider


        #endregion


    }

}
