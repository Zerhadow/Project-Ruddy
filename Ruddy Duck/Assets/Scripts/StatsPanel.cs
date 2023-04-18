using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPanel : MonoBehaviour
{
    [SerializeField] private GameObject statsPanel = null; // The panel that will display the stats
    [SerializeField] private Text nameText = null; // The text component that will display the unit name
    [SerializeField] private Text hpText = null; // The text component that will display the unit's HP
    [SerializeField] private Text attackText = null; // The text component that will display the unit's attack
    [SerializeField] private Text defenseText = null; // The text component that will display the unit's defense
    [SerializeField] private Text speedText = null; // The text component that will display the unit's speed
    [SerializeField] private Text skillText = null; // The text component that will display the unit's skill
    public BaseUnit player;

    // Start is called before the first frame update
    void Start()
    {
        // create player from player stats script
        player = GetComponent<BaseUnit>();

        // starts the panel as inactive
        statsPanel.setActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Activate the panel
            statsPanel.SetActive(true);

            // Update text fields with player stats and display
            nameText.text = player.unitName;
            hpText.text = "HP: " + player.currentHP + "/" + player.maxHP;
            attackText.text = "Attack: " + player.Attack;
            defenseText.text = "Defense: " + player.Defense;
            speedText.text = "Speed: " + player.Speed;
            skillText.text = "Skill: " + player.skill;

        }

        // remove the panel when tab key is released
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            // Deactivate the panel
            gameObject.SetActive(false);
        }
    }
}
