using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankStats : MonoBehaviour
{

    //Также классы для прокачки: LoadPoints1, SelectionToggles

    //LV это наша прокачка по уровням
    public static int tankHPLV = 1;
    public static int tankSpeedLV = 1;
    public static int tankMultipLV = 1;

    //Cost это цена перков калькулируется все это дело не так уж и рандомно 
    // в SetUpValues()
    public static float tankHUPPCost;
    public static float tankSpeedUPPCost;
    public static float tankMultipUPPCost;

    //Value это значения перков которые нужно вставить к танку как характеристики
    //оно все считается 
    public static float tankHPValue = 3;
    public static float tankSpeedValue = 0;
    public static float tankMultipValue = 0;

    private void Start()
    {
        //Debug.Log(tankHP);
    //    tankHP = 1;
    //    tankSpeed = 1;
    //    tankReload = 1;
    //    tankMultip = 1;
    }
    
    //Какраз тут считается цена перков
    public void SetUpValues()
    {
        tankHUPPCost = Mathf.Round((tankHPLV + 1) * 1000 * 0.60f);
        tankSpeedUPPCost = Mathf.Round((tankSpeedLV + 1) * 1000 * 0.20f);
        tankMultipUPPCost = Mathf.Round((tankMultipLV + 1) * 1000 * 0.40f);
    }
}
