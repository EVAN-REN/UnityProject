using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private void Awake() {
        if(Instance != null && Instance != this){
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public List<ItemSO> itemList;
    
 
    public void AddItem(ItemSO item){
        itemList.Add(item);
        InventoryUI.instance.AddItem(item);
        MessageUI.Instance.Show("你获得了一个:" + item.name);
    }

    public void RemoveItem(ItemSO item){
        itemList.Remove(item);
    }

}
