using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionToggle : MonoBehaviour
{
    
    
    //Также классы для прокачки: TankStats, LoadPoints1


    //это перки
    public Toggle HPTankToggle;
    public Toggle SpeedTankToggle;
    public Toggle MultipTankToggle;

    public Text HPText;
    public Text SpeedText;
    public Text MultipText;

    //текстбокс цены перка в нем пишется: Cost: (число)
    public Text CostUP;

    //индекс выбранного т.к не особо знаю как сделать по нормальному (типа полукастыль)
    private int selectedIndex;


    public void ActiveToggle()
    {
        if ((HPTankToggle.isOn) && (TankStats.tankHPLV + 1 <= 10))
        {
            CostUP.text = "Cost: " + TankStats.tankHUPPCost;
            selectedIndex = 0;
        }

        if ((SpeedTankToggle.isOn) && (TankStats.tankSpeedLV + 1 <= 10))
        {
            CostUP.text = "Cost: " + TankStats.tankSpeedUPPCost;
            selectedIndex = 1;
        }

        if ((MultipTankToggle.isOn) && (TankStats.tankMultipLV + 1 <= 10))
        {
            CostUP.text = "Cost: " + TankStats.tankMultipUPPCost;
            selectedIndex = 3;
        }
    }

    //происходит при нажатии на кнопку Buy тут проверяется индекс выбранного и хватает ли у нас дененг
    public void OnBuy()
    {
        switch (selectedIndex)
        {
            case 0:
                {
                    if (MoreOrLess(TankStats.tankHUPPCost) && (TankStats.tankHPLV + 1 <= 10))
                    {
                        TankStats.tankHPLV += 1; //увеличивает уровень прокачки танка на 1
                        TankStats.tankHPValue += 1;//увеличивает хп танка именно само значение 
                                                   //оно работает вставлять не нужно
                        LoadPoints1.totalPoints -= TankStats.tankHUPPCost;//т.к за все нужно платить то да снимат очки с нас
                        CostUP.text = "Cost: ";
                    }
                    if ((TankStats.tankHPLV + 1 > 10) && (HPTankToggle.isOn))
                    {
                        CostUP.text = "Max ";
                        HPText.text = "Max LV";
                    }
                    break;
                }
            case 1:
                {
                    if (MoreOrLess(TankStats.tankSpeedUPPCost) && (TankStats.tankSpeedLV + 1 <= 10))
                    {
                        TankStats.tankSpeedLV += 1;//увеличивает уровень прокачки танка на 1
                        TankStats.tankSpeedValue += 1f;//увеличивает скорость передвижения именно значение его можно поменять
                                                         //увеличивает на это число постоянно 
                                                         //нужно вставить там где скорость танка расчитывается
                        LoadPoints1.totalPoints -= TankStats.tankSpeedUPPCost;
                        CostUP.text = "Cost: ";
                    }
                    if ((TankStats.tankSpeedLV + 1 > 10) && (SpeedTankToggle.isOn))
                    {
                        CostUP.text = "Max ";
                        SpeedText.text = "Max Lv";
                    }
                    break;
                }
            case 3:
                {
                    if (MoreOrLess(TankStats.tankMultipUPPCost) && (TankStats.tankMultipLV + 1 <= 10))
                    {
                        TankStats.tankMultipLV += 1;//увеличивает уровень прокачки танка на 1
                        TankStats.tankMultipValue += 0.1f;//увеличивает домножение очков, это проценты по сути его нужно вычислить 
                                                          // от цены враг и прибавить это нужно вставить там где начисляются очки за убийство
                        LoadPoints1.totalPoints -= TankStats.tankMultipUPPCost;
                        CostUP.text = "Cost: ";
                    }
                    if ((TankStats.tankMultipLV + 1 > 10) && (MultipTankToggle.isOn))
                    {
                        CostUP.text = "Max ";
                        MultipText.text = "Max Lv";
                    }
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    //проверка на кол-во очков которые заработанны и на кол-во очков для цены
    private bool MoreOrLess(float PerkCost)
    {
        if (PerkCost <= LoadPoints1.totalPoints)
        {
            return true;
        }
        return false;
    }
}
