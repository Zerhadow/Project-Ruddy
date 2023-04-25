using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrainUnits : MonoBehaviour
{
    public GameObject unitsPannelObj;
    public GameObject trainStatPannelObj;
    public GameObject playerObj;
    public GameObject unit1Obj;
    public GameObject unit2Obj;
    public GameObject unit3Obj;
    BaseUnit player;
    PlayerController playerController;
    BaseUnit unit1;
    BaseUnit unit2;
    BaseUnit unit3;

    #region UIElements
    public TMP_Text ruddyGoldCost;
    public TMP_Text unit1GoldCost;
    public TMP_Text unit2GoldCost;
    public TMP_Text unit3GoldCost;
    #endregion

    enum UnitType {
        Ruddy,
        Unit1,
        Unit2,
        Unit3
    }

    UnitType selectedUnitType;

    // Start is called before the first frame update
    void Start()
    {
        unitsPannelObj.SetActive(false);
        trainStatPannelObj.SetActive(false);
        player = playerObj.GetComponent<BaseUnit>();
        playerController = playerObj.GetComponent<PlayerController>();
        unit1 = unit1Obj.GetComponent<BaseUnit>();
        unit2 = unit2Obj.GetComponent<BaseUnit>();
        unit3 = unit3Obj.GetComponent<BaseUnit>();
        selectedUnitType = UnitType.Ruddy;
        ruddyGoldCost.text = player.goldCost.ToString();
        unit1GoldCost.text = unit1.goldCost.ToString();
        unit2GoldCost.text = unit2.goldCost.ToString();
        unit3GoldCost.text = unit3.goldCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrainRuddy()
    {
        if (playerController.gold >= player.goldCost)
        {
            playerController.gold -= player.goldCost;
            unitsPannelObj.SetActive(false);
            trainStatPannelObj.SetActive(true);
            selectedUnitType = UnitType.Ruddy;
        }
    }

    public void TrainUnit1()
    {
        if (playerController.gold >= unit1.goldCost)
        {
            playerController.gold -= unit1.goldCost;
            unitsPannelObj.SetActive(false);
            trainStatPannelObj.SetActive(true);
            selectedUnitType = UnitType.Unit1;
        }
    }

    public void TrainUnit2()
    {
        if (playerController.gold >= unit2.goldCost)
        {
            playerController.gold -= unit2.goldCost;
            unitsPannelObj.SetActive(false);
            trainStatPannelObj.SetActive(true);
            selectedUnitType = UnitType.Unit2;
        }
    }

    public void TrainUnit3()
    {
        if (playerController.gold >= unit3.goldCost)
        {
            playerController.gold -= unit3.goldCost;
            unitsPannelObj.SetActive(false);
            trainStatPannelObj.SetActive(true);
            selectedUnitType = UnitType.Unit3;
        }
    }
    public void TrainHP() {
        switch(selectedUnitType) {
            case UnitType.Ruddy:
                player.IncreaseHP();
                break;
            case UnitType.Unit1:
                unit1.IncreaseHP();
                break;
            case UnitType.Unit2:
                unit2.IncreaseHP();
                break;
            case UnitType.Unit3:
                unit3.IncreaseHP();
                break;
        }
    }

    public void TrainATK() {
        switch(selectedUnitType) {
            case UnitType.Ruddy:
                player.IncreaseAttack();
                break;
            case UnitType.Unit1:
                unit1.IncreaseAttack();
                break;
            case UnitType.Unit2:
                unit2.IncreaseAttack();
                break;
            case UnitType.Unit3:
                unit3.IncreaseAttack();
                break;
        }
    }

    public void TrainDEF() {
        switch(selectedUnitType) {
            case UnitType.Ruddy:
                player.IncreaseDefense();
                break;
            case UnitType.Unit1:
                unit1.IncreaseDefense();
                break;
            case UnitType.Unit2:
                unit2.IncreaseDefense();
                break;
            case UnitType.Unit3:
                unit3.IncreaseDefense();
                break;
        }
    }

    public void TrainSPD() {
        switch(selectedUnitType) {
            case UnitType.Ruddy:
                player.IncreaseSpeed();
                break;
            case UnitType.Unit1:
                unit1.IncreaseSpeed();
                break;
            case UnitType.Unit2:
                unit2.IncreaseSpeed();
                break;
            case UnitType.Unit3:
                unit3.IncreaseSpeed();
                break;
        }
    }

    public void Back() {
        unitsPannelObj.SetActive(true);
        trainStatPannelObj.SetActive(false);
    }
}
