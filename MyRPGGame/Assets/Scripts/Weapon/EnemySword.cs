using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : EnemyWeapon
{
    private void Awake() {
        attackValue = 20; // 在 Awake 方法中初始化
    }
    private void OnTriggerEnter(Collider other) {
        print(attackValue);
        if(other.gameObject.tag == Tag.PLAYER){
            other.gameObject.GetComponent<PlayerHurt>().TakeDamage(attackValue);
        }
    }
}
