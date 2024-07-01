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
    private readonly float TIME_SPREAD = 300.0f;
    private readonly float RADIUS = 10.0f;
    private readonly float PI = 3.141f;
    public int numEnemies;
    private int wave;
    private int enemyPerWave;
    private float enemySpeed;

    void Start()
    {
        deltaTime = 0.0f;
        numEnemies = 0;
        enemySpeed = 1;
        wave = 1;
        enemyPerWave = 5;
        GenerateEnemyWave();
    }


    void Update()
    {
        if (deltaTime >= TIME_SPREAD) {
            GenerateEnemyWave();
            deltaTime = 0.0f;
        } else {
            deltaTime += Time.fixedDeltaTime;
        }
    }

    void GenerateEnemyWave() {
        for (int i = 0; i < enemyPerWave; i++) {
            float theta = Random.Range(0f, 2 * PI);
            position = new Vector3(Mathf.Cos(theta) * RADIUS, Mathf.Sin(theta) * RADIUS, 1);
            position += character.transform.position;
            GameObject newEnemy = Instantiate(enemy, position, Quaternion.identity);
            AIDestinationSetter enemyScript = newEnemy.GetComponent<AIDestinationSetter>();
            enemyScript.target = character.transform;
            EnemyLifecycle el = newEnemy.GetComponent<EnemyLifecycle>();
            el.eg = this;
            el.speed = enemySpeed;
            Transform childTransform = newEnemy.transform.Find("Enemy");
            SpriteRenderer sr = childTransform.GetComponent<SpriteRenderer>();
            sr.sortingLayerName = "Enemy";
            numEnemies += 1;
        }
        wave += 1;
        enemyPerWave += 1;
        enemySpeed += 0.25f;
        if(enemySpeed >= 4) {
            enemySpeed = 4;
        }
        
    }
}
