using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI descriptionText;
    public GameObject propertyGrid;
    public GameObject propertyTemplate;
    ItemSO itemSO;
    ItemUI itemUI;

    private void Start() {
        propertyTemplate.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void UpdateItemDetailUI(ItemSO itemSO, ItemUI itemUI){
        this.gameObject.SetActive(true);
        this.itemSO = itemSO;
        this.itemUI = itemUI;

        string type = "";

        switch (itemSO.itemType){
            case ItemType.Weapon:
                type = "武器";
                break;
            case ItemType.Consumable:
                type = "消耗品";
                break;
        }
        icon.sprite = itemSO.icon;
        nameText.text = itemSO.itemName;
        typeText.text = type;
        descriptionText.text = itemSO.description;

        foreach(Transform child in propertyGrid.transform){
            if(child.gameObject.activeSelf){
                Destroy(child.gameObject);
            }
        }

        foreach(Property itemProperty in itemSO.propertyList){
            string propertyStr = "";
            string propertyName = "";
            switch(itemProperty.itemPropertyType){
                case PropertyType.AttackValue:
                    propertyName = "攻击力: ";
                    break;
                case PropertyType.EnergyValue:
                    propertyName = "能量值: ";
                    break;
                case PropertyType.HPValue:
                    propertyName = "生命值: ";
                    break;
                case PropertyType.MentalValue:
                    propertyName = "精神值: ";
                    break;
                case PropertyType.SpeedValue:
                    propertyName = "速度值: ";
                    break;
            }
            propertyStr += propertyName;
            propertyStr += itemProperty.value;

            GameObject go = GameObject.Instantiate(propertyTemplate);
            go.SetActive(true);
            go.transform.SetParent(propertyGrid.transform);
            go.transform.Find("property").GetComponent<TextMeshProUGUI>().text = propertyStr;
        }
    }

    public void OnUseButtonClick() {
        InventoryUI.instance.OnItemUse(itemSO, itemUI);
        this.gameObject.SetActive(false);
        
        GameObject.FindGameObjectWithTag(Tag.PLAYER).GetComponent<Player>().UseItem(itemSO);
        
    }
}
