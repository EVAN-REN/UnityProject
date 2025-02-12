using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPropertyUI : MonoBehaviour
{

    private Image hpProgressBar;
    private TextMeshProUGUI hpText;

    private Image levelProgressBar;
    private TextMeshProUGUI levelText;

    private GameObject propertyGrid;
    private GameObject propertyTemplate;

    private Image weaponIcon;
    private GameObject uiGameObject;

    private PlayProperty pp;
    private PlayerAttack pa;

    public Sprite iconSprite;


    public static PlayerPropertyUI Instance { get; private set;}
    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        uiGameObject = transform.Find("UI").gameObject;
        hpProgressBar = transform.Find("UI/HPProgressBar/ProgressBar").GetComponent<Image>();
        hpText = transform.Find("UI/HPProgressBar/HPText").GetComponentInChildren<TextMeshProUGUI>();
        levelProgressBar = transform.Find("UI/LevelProgressBar/ProgressBar").GetComponent<Image>();
        levelText = transform.Find("UI/LevelProgressBar/LevelText").GetComponentInChildren<TextMeshProUGUI>();
        propertyGrid = transform.Find("UI/PropertyGrid").gameObject;
        propertyTemplate = transform.Find("UI/PropertyGrid/PropertyTemplate").gameObject;
        weaponIcon = transform.Find("UI/WeaponIcon").GetComponent<Image>();

        propertyTemplate.SetActive(false);

        GameObject player = GameObject.FindGameObjectWithTag(Tag.PLAYER);
        pp = player.GetComponent<PlayProperty>();
        pa = player.GetComponent<PlayerAttack>();
        UpdatePlayerPropertyUI();
        Hide();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)){
            if(uiGameObject.activeSelf){
                Hide();
            }else{
                Show();
            }
        }
    }

    public void UpdatePlayerPropertyUI(){
        hpProgressBar.fillAmount = pp.hpValue * 1.0f / pp.maxValue;
        hpText.text = pp.hpValue + "/" + pp.maxValue; 

        levelProgressBar.fillAmount = pp.currentExp * 1.0f / (pp.level * 30);
        levelText.text = pp.level.ToString(); 

        ClearGrid();
        AddProperty("饥饿值:" + pp.energyValue);
        AddProperty("精神值:" + pp.mentalValue);
        
        foreach(var item in pp.propertyDict){
            string propertyStr = "";
            if(item.Key == PropertyType.AttackValue){
                propertyStr = "攻击力:";
            }else if(item.Key == PropertyType.SpeedValue){
                propertyStr = "速度值:";
            }else{
                continue;
            }
            int sum = 0;
            foreach(var val in item.Value){
                sum += val.value;
            }
            propertyStr += sum;
            AddProperty(propertyStr);
        }

        if(pa.weaponIcon != null){
            print("1");
            weaponIcon.sprite = pa.weaponIcon;
        }else{
            weaponIcon.sprite = iconSprite;
        }
    }

    private void ClearGrid(){
        foreach(Transform child in propertyGrid.transform){
            if(child.gameObject.activeSelf){
                Destroy(child.gameObject);
            }
        }
    }

    private void AddProperty(string propertyStr){
        GameObject go = GameObject.Instantiate(propertyTemplate);
        go.SetActive(true);
        go.transform.SetParent(propertyGrid.transform);

        go.transform.Find("property").GetComponent<TextMeshProUGUI>().text = propertyStr;
    }

    private void Hide(){
        uiGameObject.SetActive(false);
    }

    private void Show(){
        uiGameObject.SetActive(true);
    }
}
