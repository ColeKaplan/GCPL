using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject enemy;
    public GameObject character;
    private Vector3 position;
    private float deltaTime;
    private readonly float TIME_SPREAD = 30.0f;
    private readonly float RADIUS = 10.0f;
    private readonly float PI = 3.141f;

    void Start()
    {
        deltaTime = 0.0f;
    }


    void Update()
    {
        if (deltaTime >= TIME_SPREAD) {
            float theta = Random.Range(0f, 2 * PI);
            position = new Vector3(Mathf.Cos(theta) * RADIUS, Mathf.Sin(theta) * RADIUS, 1);

            GameObject newEnemy = Instantiate(enemy, position, Quaternion.identity);
            //EnemyMovement enemyScript = newEnemy.GetComponent<EnemyMovement>();
            //nemyScript.character = this.character;

            deltaTime = 0.0f;
        } else {
            deltaTime += Time.fixedDeltaTime;
        }
    }
}
