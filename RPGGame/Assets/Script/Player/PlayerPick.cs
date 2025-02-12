using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPick : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == Tag.ITERACTABLE){
            PickableObject po = other.gameObject.GetComponent<PickableObject>();

            if(po != null){
                InventoryManager.Instance.AddItem(po.itemSO);
                Destroy(po.gameObject);
            }
        }
    }
}
