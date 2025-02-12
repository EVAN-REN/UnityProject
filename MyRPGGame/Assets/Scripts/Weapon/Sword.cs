using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Sword : Weapon
{

    
    private void Start() {
        player = GameObject.FindGameObjectWithTag(Tag.PLAYER);
        player.GetComponent<Animator>().runtimeAnimatorController = animatorController;
        // col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag == Tag.ENEMY){
                other.gameObject.GetComponent<EnemyHealthBar>().TakeDamage(attackValue);
        }
    }
}
