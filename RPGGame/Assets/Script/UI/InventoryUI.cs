using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance{ get ;private set;}
    private GameObject uiGameObject;
    private GameObject content;
    public GameObject itemPrefab;
    private bool isShow = false;
    public ItemDetailUI itemDetailUI;
    void Start()
    {
        uiGameObject = transform.Find("UI").gameObject;
        content = transform.Find("UI/ListBg/Scroll View/Viewport/Content").gameObject;
        Hide();
    }

    private void Awake() {
        if (instance != null && instance != this){
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.B)){
            if(isShow){
                isShow = false;
                Hide();
            }else{
                isShow = true;
                Show();
            }
        }
    }


    public void Show(){
        uiGameObject.SetActive(true);
    }
    public void Hide(){
        uiGameObject.SetActive(false);
    }
    public void AddItem(ItemSO itemSO){
        GameObject itemGo = GameObject.Instantiate(itemPrefab);
        itemGo.transform.SetParent(content.transform);
        ItemUI itemUI = itemGo.GetComponent<ItemUI>();
        itemUI.InitItem(itemSO);
    }

    public void OnClickItem(ItemSO itemSO, ItemUI itemUI){
        itemDetailUI.UpdateItemDetailUI(itemSO, itemUI);
    }

    public void OnItemUse(ItemSO itemSO, ItemUI itemUI){
        Destroy(itemUI.gameObject);

        InventoryManager.Instance.RemoveItem(itemSO);
    }

}
