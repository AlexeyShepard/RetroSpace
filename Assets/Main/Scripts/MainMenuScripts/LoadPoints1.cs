using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPoints1 : MonoBehaviour
{

    //Также классы для прокачки: TankStats, SelectionToggles

    public Text yourPoints; //текстбокс с нашими очками 
    public static float totalPoints = 1000000; // все количество очков

    //текстбоксы которые будут показывать что за перк и уровень
    public Text HPText;
    public Text SpeedText;
    public Text MultipText;

    //это те увадратики цветные которые обозначают наш уровень перков который уже есть
    public Text YourHPText;
    public Text YourSpeedText;
    public Text YourMultipText;

    void Start()
    {
        Load(); 
    }

    //происходит загрузка всего во все для того что бы отобразить
    public void Load()
    {
        yourPoints.text = "Your: " + totalPoints;
        if (TankStats.tankHPLV < 10)
            HPText.text = "HP LV: " + (TankStats.tankHPLV + 1);
        else
            HPText.text = "Max LV";
        if (TankStats.tankSpeedLV < 10)
            SpeedText.text = "Speed LV: " + (TankStats.tankSpeedLV + 1);
        else
            SpeedText.text = "Max LV";
        if (TankStats.tankMultipLV < 10)
            MultipText.text = "Multiplier LV: " + (TankStats.tankMultipLV + 1);
        else
            MultipText.text = "Max LV";

        YourHPText.text = TankStats.tankHPLV.ToString();
        YourSpeedText.text =TankStats.tankSpeedLV.ToString();
        YourMultipText.text = TankStats.tankMultipLV.ToString();
    }
}
