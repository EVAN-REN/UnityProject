using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent enemyAgent;
    private EnemyState state;
    private EnemyState childState;
    public float restTime = 1;
    private float restTimer = 0;
    public int HP = 100;
    public int exp = 20;

    private enum EnemyState{
        NormalState,
        FightingState,
        MovingState,
        RestingState
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        state = EnemyState.NormalState;
        childState = EnemyState.RestingState;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == EnemyState.NormalState){
            if(childState == EnemyState.RestingState){
                restTimer += Time.deltaTime;
                if(restTimer > restTime){
                    Vector3 randomPosition = FindRandomPosition();
                    enemyAgent.SetDestination(randomPosition);
                    childState = EnemyState.MovingState;
                }
            }else if(childState == EnemyState.MovingState){
                if(enemyAgent.remainingDistance <= 0){
                    childState = EnemyState.RestingState;
                    restTimer = 0;
                }
            }
        }

        // if(Input.GetKeyDown(KeyCode.Space)){
        //     TakeDamage(30);
        // }
    }

    private Vector3 FindRandomPosition(){
        Vector3 randomDir = new Vector3(Random.Range(-1, 1f),0, Random.Range(-1, 1f));
        return transform.position + randomDir.normalized * Random.Range(5,10);
    }

    public void TakeDamage(int damage){
        HP -= damage;
        if(HP <= 0){
            Die();
        }
    }

    private void Die(){
        GetComponent<Collider>().enabled = false;
        int count = Random.Range(0,4);
        for(int i = 0; i < count; i++){
            SpawnPickableItem();
        }
        EventCenter.EnemyDied(this);
        Destroy(this.gameObject);

    }

    private void SpawnPickableItem(){
        ItemSO item = ItemDBManager.Instance.GetRandomItem();
        GameObject go = GameObject.Instantiate(item.prefab, transform.position, Quaternion.identity);
        go.tag = Tag.ITERACTABLE;
        Animator anim = go.GetComponent<Animator>();
        if(anim != null){
            anim.enabled = false;
        }

        PickableObject po = go.AddComponent<PickableObject>();
        po.itemSO = item;

        Collider collider = go.GetComponent<Collider>();
        if(collider != null){
            collider.enabled = true;
            collider.isTrigger = false;
        }

        Rigidbody rigidbody= go.GetComponent<Rigidbody>();
        if(rigidbody != null){
            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;
        }
    }
}

