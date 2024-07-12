using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyLifecycle : MonoBehaviour
{
    public GameObject coin;
    public float speed;
    private float deltaTime;
    private float totalTime;
    private AIPath pathScript;
    public EnemyGeneration eg;
    void Start()
    {
        deltaTime = 0;
        totalTime = 0;
        pathScript = gameObject.GetComponent<AIPath>();
        pathScript.maxSpeed = speed;
    }

    
    void FixedUpdate()
    {
        deltaTime += Time.fixedDeltaTime;
        totalTime += Time.fixedDeltaTime;

        if (deltaTime >= .5f) {
            speed -= 0.01f;
            pathScript.maxSpeed = speed;
            deltaTime = 0;
        }

        if (totalTime >= 25f || speed <= .1f) {
            GameObject newCoin = Instantiate(coin, transform.position, Quaternion.identity);
            CoinBehavior coinScript = newCoin.GetComponent<CoinBehavior>();
            coinScript.character = eg.character;
            eg.numEnemies -= 1;
            Destroy(gameObject);
        }
    }
}
