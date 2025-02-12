using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameTaskState{
    Waiting,
    Executing,
    Completed,
    End
}

[System.Serializable]
public class DialogueData
{
    public string[] lines;
}

[CreateAssetMenu()]
public class GameTaskSO : ScriptableObject
{
    public GameTaskState state;
    public List<DialogueData> dialogue;
    public ItemSO startReward;
    public ItemSO endReward;

    public int enemyCountNeed = 3;
    public int currentEnemyCount = 0;

    public void Start(){
        state = GameTaskState.Executing;
        currentEnemyCount = 0;
        EventCenter.onEnemyDied += OnEnemyDied;
    }


    public void End(){
        EventCenter.onEnemyDied += OnEnemyDied;
    }

    public void OnEnemyDied(Enemy enemy){
        currentEnemyCount++;
        if(currentEnemyCount >= enemyCountNeed){
            state = GameTaskState.Completed;
            currentEnemyCount = 0;
            End();
            MessageUI.Instance.Show("任务已完成,请去领赏");
        }
    }

}
