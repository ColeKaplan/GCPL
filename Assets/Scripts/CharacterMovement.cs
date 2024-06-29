using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    private Rigidbody2D rigidBody;
    private float movementSpeed;
    
    private Vector2 movement;


    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        movementSpeed = 7;
        movement = new Vector2(0.0f, 0.0f).normalized;
        
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
        rigidBody.MovePosition(rigidBody.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
