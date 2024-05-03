using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyBehavior : MonoBehaviour
{


    [SerializeField] private Vector2 direction = Vector2.left;
    [SerializeField] private float speed = 3f;
    private SpriteRenderer spriteRenderer;
     
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update(){
        Vector2 origin = transform.position;
        origin.y += 0.3f;
        origin.x += 0.5f * direction.x;

        Debug.DrawRay(origin, direction, Color.yellow); 
        Debug.DrawRay(origin, Vector2.down, Color.green); 
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, 0.1f);
        if(hit.collider != null){
            direction *= -1;
        }
        else{
            hit = Physics2D.Raycast(origin, Vector2.down, 1f);
            if(hit.collider == null){
                direction *= -1;
            }
        }
        spriteRenderer.flipX = direction.x > 0;

        transform.Translate(speed * Time.deltaTime * direction );
    }

}
