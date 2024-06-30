using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    
    private Rigidbody2D rigidBody;
    private float movementSpeed;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;


    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        movementSpeed = 7;
        movement = new Vector2(0.0f, 0.0f).normalized;

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if (rigidBody) {
           
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");
            movement = new Vector2(moveHorizontal, moveVertical).normalized;

            
        }
    }

    void FixedUpdate()
    {
        if(movement.x == 1f && movement.y == 0f) {
            spriteRenderer.sprite = rightSprite;
        }
        if(movement.x == -1f && movement.y == 0f) {
            spriteRenderer.sprite = leftSprite;
        }
        if(movement.x == 0f && movement.y == 1f) {
            spriteRenderer.sprite = upSprite;
        }
        if(movement.x == 0f && movement.y == -1f) {
            spriteRenderer.sprite = downSprite;
        }

        rigidBody.MovePosition(rigidBody.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider is CircleCollider2D)
        {
            SceneManager.LoadScene(2);
        }
    }
}
