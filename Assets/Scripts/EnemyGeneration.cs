using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject enemy;
    public GameObject character;
    private Vector3 position;
    private float deltaTime;
    private readonly float TIME_SPREAD = 500.0f;
    private readonly float RADIUS = 10.0f;
    private readonly float PI = 3.141f;
    public int numEnemies;

    void Start()
    {
        deltaTime = 0.0f;
        numEnemies = 0;
        GenerateEnemy();
    }


    void Update()
    {
        if (deltaTime >= TIME_SPREAD) {
            GenerateEnemy();
            deltaTime = 0.0f;
        } else {
            deltaTime += Time.fixedDeltaTime;
        }
    }

    void GenerateEnemy() {
        float theta = Random.Range(0f, 2 * PI);
        position = new Vector3(Mathf.Cos(theta) * RADIUS, Mathf.Sin(theta) * RADIUS, 1);

        GameObject newEnemy = Instantiate(enemy, position, Quaternion.identity);
        AIDestinationSetter enemyScript = newEnemy.GetComponent<AIDestinationSetter>();
        enemyScript.target = character.transform;
        EnemyLifecycle el = newEnemy.GetComponent<EnemyLifecycle>();
        el.eg = this;
        Transform childTransform = newEnemy.transform.Find("Enemy");
        SpriteRenderer sr = childTransform.GetComponent<SpriteRenderer>();
        sr.sortingLayerName = "Enemy";
        numEnemies += 1;
    }
}
