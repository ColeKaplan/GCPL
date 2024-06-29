using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    public GameObject character;
    private Rigidbody2D rigidBody;
    private Vector2 movement;
    private float movementSpeed;
    private readonly float MIN_MOVEMENT_SPEED = 0.2f;
    private readonly float SPEED_DELTA = 0.0005f;
    

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        movement = new Vector2(50.0f, 50.0f);
        movementSpeed = 3.0f;
        
    }

    void Update()
    {
        float characterX = character.transform.position.x;
        float characterY = character.transform.position.y;
        movement = new Vector2(characterX - rigidBody.transform.position.x, characterY - rigidBody.transform.position.y).normalized;
        
        if (movementSpeed < MIN_MOVEMENT_SPEED) {
            Destroy(gameObject, 0.1f);
        } else {
            movementSpeed -= SPEED_DELTA;
        }
        
    }

    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
