using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : StateMachineBehaviour{
    private BoxCollider weaponCollider;
    public void UpdateWeaponCollider()
    {
        GameObject weapon = GameObject.FindGameObjectWithTag(Tag.WEAPON);
        if (weapon != null)
        {
            weaponCollider = weapon.GetComponent<BoxCollider>();
        }
        else
        {
            weaponCollider = null; // 确保武器不存在时不会导致空引用
        }
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         UpdateWeaponCollider();
        // 动画进入时开启碰撞器
        if (weaponCollider != null)
        {
            weaponCollider.enabled = true;
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 动画退出时关闭碰撞器
        if (weaponCollider != null)
        {
            weaponCollider.enabled = false;
        }
    }
}
