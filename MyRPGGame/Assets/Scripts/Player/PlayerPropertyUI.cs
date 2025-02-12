using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPropertyUI : MonoBehaviour
{
    public static PlayerPropertyUI Instance {get; private set;}
    private Image hpProgressBar;
    private Image mpProgressBar;
    private Image levelProgressBar;
    private TextMeshProUGUI levelText;
    public int maxHealth = 100;
    public int currentHealth = 100;

    public int maxMP = 100;
    public int currentMP = 100;

    public int level = 1;
    public int currentExp = 0;

    private void Awake() {
        if(Instance != null && Instance != this){
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        hpProgressBar = transform.Find("PropertyUI/HPProgressBar/ProgressBar").GetComponent<Image>();
        levelProgressBar = transform.Find("PropertyUI/LevelProgressBar/ProgressBar").GetComponent<Image>();
        levelText = transform.Find("PropertyUI/LevelProgressBar/LevelText").GetComponent<TextMeshProUGUI>();
        mpProgressBar = transform.Find("PropertyUI/MPProgressBar/ProgressBar").GetComponent<Image>();
        hpProgressBar.fillAmount = currentHealth * 1.0f / maxHealth;
        mpProgressBar.fillAmount = currentMP * 1.0f / maxMP;
        levelText.text = level.ToString();
        levelProgressBar.fillAmount = currentExp * 1.0f / (level * 30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool TakeDamage(int attackValue){
        currentHealth -= attackValue;
        if(currentHealth <= 0){
            currentHealth = 0;
            hpProgressBar.fillAmount = currentHealth * 1.0f / maxHealth;
            return false;
        }
        hpProgressBar.fillAmount = currentHealth * 1.0f / maxHealth;
        return true;
    }

    public bool CostMP(int mpCost){
        if(currentMP < mpCost){
            return false;
        }
        currentMP -= mpCost;
        mpProgressBar.fillAmount = currentMP * 1.0f / maxMP;
        return true;
    }

    public void AddExp(int exp){
        currentExp += exp;
        if(currentExp >= level * 30){
            currentExp -= level * 30;
            level++;
        }
        levelText.text = level.ToString();
        levelProgressBar.fillAmount = currentExp * 1.0f / (level * 30);
    }
}
