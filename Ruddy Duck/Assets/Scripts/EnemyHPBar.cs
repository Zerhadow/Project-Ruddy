using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBar : MonoBehaviour
{
    public GameObject healthBarUI;
    public Slider slider;
    private GameObject enemy;
    BaseUnit stats;
    
    // Start is called before the first frame update
    void Start()
    {
        enemy = this.gameObject;
        stats = enemy.GetComponent<BaseUnit>();
        slider.value = stats.GetCurrHP();
        //convert double to float
        slider.maxValue = (float)stats.maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = stats.GetCurrHP();

        if(stats.GetCurrHP() == 0) return;

        if(stats.GetCurrHP() < stats.maxHP) healthBarUI.SetActive(true);
    }
}