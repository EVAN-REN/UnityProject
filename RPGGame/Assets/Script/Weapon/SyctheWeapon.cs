using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyctheWeapon : Weapon
{
    private Animator anim;
    public int atkValue = 50;

    private const string ANIM_PARM_ISATTACK = "isAttack";

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update() {
        
    }

    public override void Attack()
    {
        anim.SetTrigger(ANIM_PARM_ISATTACK);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == Tag.ENEMY){
            other.GetComponent<Enemy>().TakeDamage(atkValue);
        }
    }
}
