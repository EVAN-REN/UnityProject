using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCObject : InteractableObject
{
    public string NPCName;
    public string[] contentList;
    protected override void Interact()
    {
        DialogueUI.instance.Show(NPCName, contentList);
    }
}
