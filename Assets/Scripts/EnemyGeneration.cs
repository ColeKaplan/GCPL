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
    private readonly float TIME_SPREAD = 15.0f;
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


    void FixedUpdate()
    {
        if (deltaTime >= TIME_SPREAD) {
            GenerateEnemyWave();
            deltaTime = 0.0f;
        } else {
            deltaTime += Time.fixedDeltaTime;
        }
    }

    void GenerateEnemyWave() {
        int waitCount = 0;
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

            waitCount += 1;
            if (waitCount >= 2) {
                StartCoroutine(WaitRandomTime());
            }
        }
        wave += 1;
        enemyPerWave += 1;
        if (enemyPerWave > 15) {
            enemyPerWave = 15;
        }
        enemySpeed += 0.4f;
        if(enemySpeed > 7) {
            enemySpeed = 7;
        }
        // TIME_SPREAD -= .5;
        // if (TIME_SPREAD <= 12.5) {
        //     TIME_SPREAD = 12.5;
        // }
        
    }

    IEnumerator WaitRandomTime()
    {
        float waitTime = Random.Range(0f, 2f);
        yield return new WaitForSeconds(waitTime);
    }
}
