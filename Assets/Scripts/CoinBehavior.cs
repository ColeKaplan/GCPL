using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    
    public GameObject character;
    private float deltaTime;

    void Start()
    {
        
        deltaTime = 0;
    }

    
    void FixedUpdate()
    {
        deltaTime += Time.fixedDeltaTime;
        if (deltaTime >= 10) {
            Destroy(gameObject);
        }
    }
}
