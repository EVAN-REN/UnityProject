using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    public float moveSpeed = 5;
    private bool isUsingKeyboard = false;

    float rotationSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseInput(); // 处理鼠标输入
        HandleKeyboardInput(); // 处理键盘输入
        
    }

    private void HandleMouseInput(){
        if(Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;
            bool isCollide = Physics.Raycast(ray, out hit);
            if(isCollide){
                isUsingKeyboard = false; // 切换到鼠标控制
                playerAgent.isStopped = false; // 启用 NavMeshAgent
                if(hit.collider.tag == Tag.GROUND){
                    
                    playerAgent.stoppingDistance = 0;
                    playerAgent.SetDestination(hit.point);
                }else if(hit.collider.tag == "Iteractable"){
                   
                    hit.collider.GetComponent<InteractableObject>().OnClick(playerAgent);
                }
                
            }
        }
    }

    private void HandleKeyboardInput()
    {
        // 获取键盘输入
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        if (moveDirection.sqrMagnitude > 0.01f) // 当有键盘输入
        {
            isUsingKeyboard = true; // 切换到键盘控制
            playerAgent.isStopped = true; // 停止 NavMeshAgent
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

            // 角色面向移动方向
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * rotationSpeed);
        }
    }
    
}
