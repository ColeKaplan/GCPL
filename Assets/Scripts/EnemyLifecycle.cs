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
    }

    
    void Update()
    {
        deltaTime += Time.fixedDeltaTime;
        totalTime += Time.fixedDeltaTime;
        if (deltaTime >= 10f) {
            speed -= 0.01f;
            pathScript.maxSpeed = speed;
            print("speed: " + speed + "   maxSpeed: " + pathScript.maxSpeed);
            deltaTime = 0;
        }

        if (totalTime >= 400f || speed <= .1f) {
            GameObject newCoin = Instantiate(coin, transform.position, Quaternion.identity);
            CoinBehavior coinScript = newCoin.GetComponent<CoinBehavior>();
            coinScript.character = eg.character;
            eg.numEnemies -= 1;
            Destroy(gameObject);
        }
    }
}
