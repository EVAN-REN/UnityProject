using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    private Animator animator;
    private const string ANIM_PARM_BEHURT = "beHurt";
    private const string ANIM_PARM_ISDIE = "isDie";
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int attackValue){
        bool live = PlayerPropertyUI.Instance.TakeDamage(attackValue);

        if(!live){
            animator.SetTrigger(ANIM_PARM_ISDIE);
        }else{
            animator.SetTrigger(ANIM_PARM_BEHURT);
        }
    }

}
