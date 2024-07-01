using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyLifecycle : MonoBehaviour
{
    public GameObject coin;
    public float speed;
    private float deltaTime;
    private AIPath pathScript;
    public EnemyGeneration eg;
    void Start()
    {
        deltaTime = 0;
        pathScript = gameObject.GetComponent<AIPath>();
    }

    
    void Update()
    {
        deltaTime += Time.fixedDeltaTime;
        if (deltaTime >= 600f) {
            speed -= 0.001f;
            pathScript.maxSpeed = speed;
        }

        if (speed <= 0.1f) {
            GameObject newCoin = Instantiate(coin, transform.position, Quaternion.identity);
            CoinBehavior coinScript = newCoin.GetComponent<CoinBehavior>();
            coinScript.character = eg.character;
            eg.numEnemies -= 1;
            Destroy(gameObject);
        }
    }
}
