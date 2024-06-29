using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject enemy;
    public GameObject character;
    private Vector3 position;
    private float deltaTime;

    void Start()
    {
        deltaTime = 0.0f;
    }


    void Update()
    {
        if (deltaTime >= 5.0f) {
            position = new Vector3(0, 0, 1);
            GameObject newEnemy = Instantiate(enemy, position, Quaternion.identity);
            EnemyMovement enemyScript = newEnemy.GetComponent<EnemyMovement>();
            enemyScript.character = this.character;

            deltaTime = 0.0f;
        } else {
            deltaTime += Time.fixedDeltaTime;
        }
    }
}
