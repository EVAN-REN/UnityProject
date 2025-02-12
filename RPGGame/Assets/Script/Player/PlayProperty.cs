using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayProperty : MonoBehaviour
{
    public Dictionary<PropertyType, List<Property>> propertyDict;
    // Start is called before the first frame update

    public int maxValue = 100;
    public int hpValue = 0;
    public int energyValue = 0;
    public int mentalValue = 0;
    public int level = 1;
    public int currentExp = 0;
    void Awake()
    {
        propertyDict = new Dictionary<PropertyType, List<Property>>();
        propertyDict.Add(PropertyType.HPValue, new List<Property>());
        propertyDict.Add(PropertyType.EnergyValue, new List<Property>());
        propertyDict.Add(PropertyType.MentalValue, new List<Property>());
        propertyDict.Add(PropertyType.AttackValue, new List<Property>());
        propertyDict.Add(PropertyType.SpeedValue, new List<Property>());
        
        AddProperty(PropertyType.HPValue, 100);
        AddProperty(PropertyType.EnergyValue, 100);
        AddProperty(PropertyType.MentalValue, 100);

        EventCenter.onEnemyDied += OnEnemyDied;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseDrug(ItemSO itemSO){
        foreach(Property prop in itemSO.propertyList){
            AddProperty(prop.itemPropertyType, prop.value);
        }
    }

    public void AddProperty(PropertyType pt, int value){
        switch(pt){
            case PropertyType.HPValue:
                hpValue += value;
                return;
            case PropertyType.EnergyValue:
                energyValue += value;
                return;
            case PropertyType.MentalValue:
                mentalValue += value;
                return;
        }

        List<Property> list;
        propertyDict.TryGetValue(pt, out list);
        list.Add(new Property(pt, value));
    }

    public void RemoveProperty(PropertyType pt, int value){
        switch(pt){
            case PropertyType.HPValue:
                hpValue -= value;
                return;
            case PropertyType.EnergyValue:
                energyValue -= value;
                return;
            case PropertyType.MentalValue:
                mentalValue -= value;
                return;
        }

        List<Property> list;
        propertyDict.TryGetValue(pt, out list);

        list.Remove(list.Find(x => x.value == value));
    }

    private void OnDestroy(){
        EventCenter.onEnemyDied -= OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy){
        currentExp += enemy.exp;
        if(currentExp >= level * 30){
            currentExp -= level * 30;
            level++;
        }
        PlayerPropertyUI.Instance.UpdatePlayerPropertyUI();
    }
}
