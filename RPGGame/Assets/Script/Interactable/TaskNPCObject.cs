using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskNPCObject : InteractableObject
{
    public string npcName;
    public GameTaskSO gameTaskSO;

    private void Start() {
        gameTaskSO.state = GameTaskState.Waiting;
    }
    protected override void Interact()
    {
        switch(gameTaskSO.state){
            case GameTaskState.Waiting:
                DialogueUI.instance.Show(npcName, gameTaskSO.dialogue[0].lines, OnDialogueEnd);
                break;
            case GameTaskState.Executing:
                DialogueUI.instance.Show(npcName, gameTaskSO.dialogue[1].lines);
                break;
            case GameTaskState.Completed:
                DialogueUI.instance.Show(npcName, gameTaskSO.dialogue[2].lines, OnDialogueEnd);
                break;
            case GameTaskState.End:
                DialogueUI.instance.Show(npcName, gameTaskSO.dialogue[3].lines);
                break;
        }  
    }

    public void OnDialogueEnd(){
        switch(gameTaskSO.state){
            case GameTaskState.Waiting:
                InventoryManager.Instance.AddItem(gameTaskSO.startReward);
                gameTaskSO.Start();
                MessageUI.Instance.Show("你接受了一个任务");
                break;
            case GameTaskState.Executing:
                break;
            case GameTaskState.Completed:
                InventoryManager.Instance.AddItem(gameTaskSO.endReward);
                gameTaskSO.state = GameTaskState.End;
                MessageUI.Instance.Show("任务已提交");
                break;
            case GameTaskState.End:
                break;
        } 
    }
}
