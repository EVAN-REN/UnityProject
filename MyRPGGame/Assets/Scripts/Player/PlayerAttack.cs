using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private string weaponPosition = "root/pelvis/spine_01/spine_02/spine_03/clavicle_r/upperarm_r/lowerarm_r/hand_r/weapon_r";
    public ItemSO item;
    private GameObject weaponGo;
    private BoxCollider weaponCollider;
    private Animator animator;
    private const string ANIM_PARM_ISATTACK1 = "isAttack1";
    private const string ANIM_PARM_ISATTACK2 = "isAttack2";
    private const string ANIM_PARM_ISATTACK3 = "isAttack3";
    private const string ANIM_PARM_ISATTACK4 = "isAttack4";
    // Start is called before the first frame update
    void Start()
    {
        LoadWeapon(item);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnAttack();
    }

    public void LoadWeapon(ItemSO itemSO){
        if(weaponGo != null){
            Destroy(weaponGo.gameObject);
            weaponGo = null;
        }

        weaponGo = GameObject.Instantiate(itemSO.prefab);
        Transform weaponParent = transform.Find(weaponPosition);
        weaponGo.transform.SetParent(weaponParent);

        // 初始化位置和旋转
        weaponGo.transform.localPosition = Vector3.zero;
        weaponGo.transform.localRotation = Quaternion.identity;

        weaponCollider = weaponGo.GetComponent<BoxCollider>();

    }

    private void OnAttack(){
        // WeaponColliderOn();
        if(Input.GetKeyDown(KeyCode.J)){
            animator.SetTrigger(ANIM_PARM_ISATTACK1);
        }else if(Input.GetKeyDown(KeyCode.U)){
            animator.SetTrigger(ANIM_PARM_ISATTACK2);
        }else if(Input.GetKeyDown(KeyCode.I)){
            animator.SetTrigger(ANIM_PARM_ISATTACK3);
        }else if(Input.GetKeyDown(KeyCode.O)){
            if(PlayerPropertyUI.Instance.CostMP(20)){
                animator.SetTrigger(ANIM_PARM_ISATTACK4);
            }
        }
    }
    

}
