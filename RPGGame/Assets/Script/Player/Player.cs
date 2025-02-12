using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    private PlayerAttack playerAttack;
    private PlayProperty playProperty;
    // Start is called before the first frame update
    void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
        playProperty = GetComponent<PlayProperty>();
    }

    public void UseItem(ItemSO itemSO){
        switch(itemSO.itemType){
            case ItemType.Weapon:
                playerAttack.LoadWeapon(itemSO);
                break;
            case ItemType.Consumable:
                playProperty.UseDrug(itemSO);
                break;
        }
    }
}
