using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;
    public ItemSO itemSO;
    
    public void InitItem(ItemSO itemSO){
        string type = "";
        print(itemSO.itemType);
        switch (itemSO.itemType){
            case ItemType.Weapon:
                type = "武器";
                break;
            case ItemType.Consumable:
                type = "消耗品";
                break;
        }
        iconImage.sprite = itemSO.icon;
        nameText.text = itemSO.itemName;
        typeText.text = type;
        this.itemSO = itemSO;
    }

    public void OnClick(){
        InventoryUI.instance.OnClickItem(itemSO, this);
    }
}
