using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI instance{get; private set;}
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI contentText;
    private Button continueButton;
    private GameObject uiGameObject;

    private List<string> contentList;

    private Action OnDialogueEnd;
    private int contentIndex = 0;

    private void Start(){
        nameText = transform.Find("UI/NameTextBg/NameText").GetComponent<TextMeshProUGUI>();
        contentText = transform.Find("UI/ContentText").GetComponent<TextMeshProUGUI>();
        continueButton = transform.Find("UI/ContinueButton").GetComponent<Button>();
        continueButton.onClick.AddListener(this.OnContinueButtonClick);
        uiGameObject = transform.Find("UI").gameObject;
        Hide();
    }


    private void Awake()
    {
        if(instance != null && instance != this){
            Destroy(this.gameObject);
            return;
        }else{
            instance = this;
        }       
    }

    public void Show(){
        uiGameObject.SetActive(true);
    }

    public void Show(string name, string[] contents, Action OnDialogueEnd){
        nameText.text = name;
        contentList = new List<string>();
        contentList.AddRange(contents);
        if(contentList.Count > 0){
            contentText.text = contentList[0];
            contentIndex = 0;
            uiGameObject.SetActive(true);
        }
        this.OnDialogueEnd = OnDialogueEnd;
    }

    public void Show(string name, string[] contents){
        nameText.text = name;
        contentList = new List<string>();
        contentList.AddRange(contents);
        if(contentList.Count > 0){
            contentText.text = contentList[0];
            contentIndex = 0;
            uiGameObject.SetActive(true);
        }
    }

    public void Hide(){
        uiGameObject.SetActive(false);
    }

    private void OnContinueButtonClick(){
        contentIndex++;
        if(contentIndex >= contentList.Count){
            OnDialogueEnd();
            Hide();
            return;
        }
        contentText.text = contentList[contentIndex];
    }

}
