using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerMove : MonoBehaviour
{
    
    public float speed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.8f;
    public float turnSpeed = 10f;
    private CharacterController controller;
    private Vector3 velocity;              
    private bool isGrounded;

    public bool isMoving = false;


    private const string ANIM_PARM_ISJUMP = "isJump";
    private const string ANIM_PARM_STARTMOVE = "startMove";
    private const string ANIM_PARM_ENDMOVE = "endMove";

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckOnGround();
        HandleKeyboardInput();
    }

    private void HandleKeyboardInput(){
        OnMove();
        OnJump();
    }

    private void CheckOnGround(){
        isGrounded = controller.isGrounded;

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
    }

    private void OnMove(){
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0f, vertical);

        if (move.magnitude > 0.1f)
        {
            if(isMoving == false){
                animator.SetTrigger(ANIM_PARM_STARTMOVE);
                isMoving = true;
            }
            Vector3 dir = new Vector3(horizontal, 0, vertical);

            Quaternion targetRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

            controller.Move(move.normalized * speed * Time.deltaTime);
        }else{
            if(isMoving == true){
                animator.SetTrigger(ANIM_PARM_ENDMOVE);
                isMoving = false;
            }
        }

        
    }

    private void OnJump(){
        if(Input.GetKeyDown(KeyCode.K)){
            animator.SetTrigger(ANIM_PARM_ISJUMP);
        }
    }

    
}
