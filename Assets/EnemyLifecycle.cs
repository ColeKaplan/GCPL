using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyLifecycle : MonoBehaviour
{
    public GameObject coin;
    private float speed;
    private float deltaTime;
    private AIPath pathScript;
    public EnemyGeneration eg;
    void Start()
    {
        speed = 1;
        deltaTime = 0;
        pathScript = gameObject.GetComponent<AIPath>();
    }

    
    void Update()
    {
        deltaTime += Time.fixedDeltaTime;
        if (deltaTime >= 500f) {
            speed -= 0.001f;
            pathScript.maxSpeed = speed;
        } 

        if (speed <= 0.1f) {
            Instantiate(coin, transform.position, Quaternion.identity);
            eg.numEnemies -= 1;
            Destroy(gameObject);
        }
    }
}
