using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    
    public GameObject character;

    void Start()
    {
        

    }

    
    void Update()
    {
        float distance = Vector3.Distance(character.transform.position, gameObject.transform.position);
        if (distance <= 1.5f) {
            CharacterMovement.score += 1;
            Destroy(gameObject);
        }
    }
}
