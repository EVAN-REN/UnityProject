using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent enemyAgent;

    public float restTime = 1.5f;
    public float stopDistance = 0.7f;
    private float restTimer = 0;
    private const string ANIM_PARM_ISIDLE = "isIdle";
    private const string ANIM_PARM_ISMOVE = "isMove";
    private const string ANIM_PARM_ISATTACK = "isAttack";
    private float attackCooldownTimer = 0; 
    public float attackCooldown = 1f;   
    public float attackProbability = 0.8f;
    private EnemyState state;
    private Transform playerTransform;
    private Animator animator;
    private Vector3 lastTargetPosition;
    private enum EnemyState{
        NormalState,
        MovingState,
        AttackState
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        state = EnemyState.NormalState;
        playerTransform = GameObject.FindGameObjectWithTag(Tag.PLAYER).transform;
        enemyAgent.stoppingDistance = stopDistance;

        
    }


    // Update is called once per frame
    void Update()
    {

        
        if(state == EnemyState.MovingState){
            if(enemyAgent != null && enemyAgent.pathPending == false){
                if(enemyAgent.remainingDistance <= stopDistance){
                    state = EnemyState.NormalState;
                    animator.ResetTrigger(ANIM_PARM_ISMOVE);
                    animator.SetTrigger(ANIM_PARM_ISIDLE);
                }else{
                    // 如果目标位置显著变化才更新路径
                    if (Vector3.Distance(lastTargetPosition, playerTransform.position) > 0.1f)
                    {
                        lastTargetPosition = playerTransform.position;
                        enemyAgent.SetDestination(playerTransform.position);
                    }
                }
            }
        }else if(state == EnemyState.NormalState){
            attackCooldownTimer += Time.deltaTime;

            // 让敌人始终面向玩家
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            direction.y = 0; // 防止在垂直方向发生旋转
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            //几率攻击
            if(Random.Range(0f, 1f) < attackProbability){
                if(attackCooldownTimer > attackCooldown){
                    state = EnemyState.AttackState;
                    animator.ResetTrigger(ANIM_PARM_ISIDLE);
                    animator.SetTrigger(ANIM_PARM_ISATTACK);
                    attackCooldownTimer = 0f;
                }
                
            }else{
                restTimer += Time.deltaTime;
                if(restTimer > restTime){
                    enemyAgent.SetDestination(playerTransform.position);
                    state = EnemyState.MovingState;
                    animator.ResetTrigger(ANIM_PARM_ISIDLE);
                    animator.SetTrigger(ANIM_PARM_ISMOVE);
                    restTimer = 0f;
                }
            }
            
        }else if(state == EnemyState.AttackState){
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("Enemy_attack") || stateInfo.normalizedTime >= 1.0f)
            {
                state = EnemyState.NormalState;
                animator.ResetTrigger(ANIM_PARM_ISATTACK);
                animator.SetTrigger(ANIM_PARM_ISIDLE);
            }
        }
    }

    

    

}
