using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageUI : MonoBehaviour
{
    public static MessageUI Instance { get; private set;}
    private TextMeshProUGUI messageText;

    private void Awake() {
        if(Instance != null && Instance != this){
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start() {
        messageText = transform.Find("Text").GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        if(messageText.enabled == true){
            Color color = messageText.color;
            float alpha = Mathf.Lerp(color.a, 0, Time.deltaTime);
            messageText.color = new Color(color.r, color.g, color.b, alpha);

            if(alpha == 0){
                messageText.enabled = false;
            }
        }
    }

    public void Show(string message){
        messageText.enabled = true;
        messageText.text = message;
        messageText.color = Color.white;
    }

    private void Hide(){
        messageText.enabled = false;
    }


}
