using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemDBManager : MonoBehaviour
{
    public static ItemDBManager Instance { get; private set;}
    public ItemDBSO itemDB;
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance != null && Instance != this){
            Destroy(this.gameObject);
        }
        Instance = this;
    }


    public ItemSO GetRandomItem(){
        int itemIndex = Random.Range(0, 4);
        return itemDB.itemList[itemIndex];
    }
}
