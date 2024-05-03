using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class GoombaMove : MonoBehaviour
{
    private InputAction move;
    [SerializeField] private InputActionAsset actions;
    [SerializeField] float speed = 0.5f;
    private InputActionMap actionMap;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private InputAction jump;
    private Rigidbody2D rb;

    private bool isGrounded = true;
    private bool isJumping = true;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();   
        animator = GetComponent<Animator>();

        actionMap = actions.FindActionMap("Goomba");
        move = actionMap.FindAction("Move");
        jump = actionMap.FindAction("Jump");
        jump.performed += ctx => { OnJump(ctx);};
    }

    private void OnEnable(){
        actionMap.Enable();
    }

    private void OnDisable(){
        actionMap.Disable();
    }

    private void OnJump(InputAction.CallbackContext context){
        if (!isGrounded) return;
        rb.velocity += 6 * Vector2.up;
        isJumping = true;
    }

    private void Move(Vector2 moveVector){
        spriteRenderer.flipX = moveVector.x < 0;
        moveVector *= Time.deltaTime * speed;
        transform.Translate(moveVector);
    }

    // Update is called once per frame
    void Update()
    {   

        Vector2 origin = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.02f);
        isGrounded = hit.collider != null;
        isJumping = !isGrounded && isJumping;

        animator.SetBool("isJumping", !isGrounded);

        Vector2 moveVector = move.ReadValue<Vector2>();
        if(moveVector.x != 0){
            animator.SetBool("isMoving", true);
            Move(moveVector);
        }
        else{
            animator.SetBool("isMoving", false);
        }
    }
}
