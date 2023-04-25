using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayStatsOfParty : MonoBehaviour
{
    KeyCode tab = KeyCode.Tab;
    public GameObject statsPanelObj;
    bool panelOpen = false;
    public GameObject playerObj;
    public GameObject unit1Obj;
    public GameObject unit2Obj;
    public GameObject unit3Obj;
    BaseUnit player;
    BaseUnit unit1;
    BaseUnit unit2;
    BaseUnit unit3;

    #region Player Panel
    public TMP_Text nameText;
    public TMP_Text hpText;
    public TMP_Text attackText;
    public TMP_Text defenseText;
    public TMP_Text speedText;
    public TMP_Text skillText;
    #endregion

    #region Unit1 Panel
    public TMP_Text nameText1;
    public TMP_Text hpText1;
    public TMP_Text attackText1;
    public TMP_Text defenseText1;
    public TMP_Text speedText1;
    public TMP_Text skillText1;
    #endregion

    #region Unit2 Panel
    public TMP_Text nameText2;
    public TMP_Text hpText2;
    public TMP_Text attackText2;
    public TMP_Text defenseText2;
    public TMP_Text speedText2;
    public TMP_Text skillText2;
    #endregion

    #region Unit3 Panel
    public TMP_Text nameText3;
    public TMP_Text hpText3;
    public TMP_Text attackText3;
    public TMP_Text defenseText3;
    public TMP_Text speedText3;
    public TMP_Text skillText3;
    #endregion

    private void Awake() {
        statsPanelObj.SetActive(false);
        player = playerObj.GetComponent<BaseUnit>();
        unit1 = unit1Obj.GetComponent<BaseUnit>();
        unit2 = unit2Obj.GetComponent<BaseUnit>();
        unit3 = unit3Obj.GetComponent<BaseUnit>();
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(tab))
        {
            if(panelOpen) {
                statsPanelObj.SetActive(false);
                panelOpen = false;
            } else {
                statsPanelObj.SetActive(true);
                DisplayStats(player, unit1, unit2, unit3);
                panelOpen = true;
            }
        }
    }

    void DisplayStats(BaseUnit player, BaseUnit unit1, BaseUnit unit2, BaseUnit unit3) {
        // Update text fields with player stats and display
        nameText.text = player.unitName;
        // Debug.Log("Player object: " + player.unitName);
        hpText.text = "HP: " + player.currentHP + "/" + player.maxHP;
        // Debug.Log("Player HP: " + player.currentHP + "/" + player.maxHP);
        attackText.text = "Atk: " + player.Attack;
        // Debug.Log("Player attack: " + player.Attack);
        defenseText.text = "Def: " + player.Defense;
        // Debug.Log("Player defense: " + player.Defense);
        speedText.text = "Spd: " + player.Speed;
        // Debug.Log("Player speed: " + player.Speed);
        skillText.text = "Skl: " + player.skill;
        // Debug.Log("Player skill: " + player.skill);

        // UNIT 1
        nameText1.text = unit1.unitName;
        hpText1.text = "HP: " + unit1.currentHP + "/" + unit1.maxHP;
        attackText1.text = "Atk: " + unit1.Attack;
        defenseText1.text = "Def: " + unit1.Defense;
        speedText1.text = "Spd: " + unit1.Speed;
        skillText1.text = "Skl: " + unit1.skill;

        // // UNIT 2
        nameText2.text = unit2.unitName;
        hpText2.text = "HP: " + unit2.currentHP + "/" + unit2.maxHP;
        attackText2.text = "Atk: " + unit2.Attack;
        defenseText2.text = "Def: " + unit2.Defense;
        speedText2.text = "Spd: " + unit2.Speed;
        skillText2.text = "Skl: " + unit2.skill;

        // // UNIT 3
        nameText3.text = unit3.unitName;
        hpText3.text = "HP: " + unit3.currentHP + "/" + unit3.maxHP;
        attackText3.text = "Atk: " + unit3.Attack;
        defenseText3.text = "Def: " + unit3.Defense;
        speedText3.text = "Spd: " + unit3.Speed;
        skillText3.text = "Skl: " + unit3.skill;

    }
}
