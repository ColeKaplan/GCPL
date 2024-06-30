using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemySprite : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    private Vector3 movement;
    private AIPath aiPath;
    
    void Start()
    {
        aiPath = GetComponentInParent<AIPath>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = rightSprite;
    }

    
    void Update()
    {
        if (aiPath != null)
        {
            Vector3 movementDirection = aiPath.desiredVelocity;

            movement = movementDirection.normalized;
            
        }
        
        if (Mathf.Abs(movement.x) >= Mathf.Abs(movement.y)) {
            if (movement.x >= 0) {
                spriteRenderer.sprite = rightSprite;
            } else {
                spriteRenderer.sprite = leftSprite;
            }
        } else {
            if (movement.y >= 0) {
                spriteRenderer.sprite = upSprite;
            } else {
                spriteRenderer.sprite = downSprite;
            }
        }
    }
}
