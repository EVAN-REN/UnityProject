using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public int id;
    public string itemName;
    public ItemType itemType;
    public string description;
    public List<Property> propertyList;
    public Sprite icon;
    public GameObject prefab;
    
}

public enum ItemType{
    Weapon,
    Consumable
}

[Serializable]
public class Property{
    public PropertyType itemPropertyType;
    public int value;

    public Property(){

    }

    public Property(PropertyType pt, int value){
        itemPropertyType = pt;
        this.value = value;
    }
}

public enum PropertyType{
    HPValue,
    EnergyValue,
    MentalValue,
    SpeedValue,
    AttackValue
}
