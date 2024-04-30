using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class GoombaMove : MonoBehaviour
{
    private InputAction move;
    [SerializeField] private InputActionAsset actions;
    [SerializeField] float speed = 0.5f;
    private InputActionMap actionMap;
    private SpriteRenderer renderer;
    private Animator animator;


    private void Awake()
    {
        actionMap = actions.FindActionMap("Goomba");
        move = actionMap.FindAction("Move");
        renderer = GetComponent<SpriteRenderer>();   
        animator = GetComponent<Animator>();
    }

    private void OnEnable(){
        actionMap.Enable();
    }

    private void OnDisable(){
        actionMap.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = move.ReadValue<Vector2>();

        if(moveVector.x != 0){
            animator.SetBool("isMoving", true);
            renderer.flipX = moveVector.x < 0;
            moveVector *= Time.deltaTime * speed;
            transform.Translate(moveVector);
        }
        else{
            animator.SetBool("isMoving", false);
        }

    }
}
