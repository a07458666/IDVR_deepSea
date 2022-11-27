using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // number of enemies on z
    public int numZ;

    // number of enemies on x
    public int numX;

    // number of layers
    public int numY;
    
    // separation
    public float separation;

    // BOSS Size
    public float bossSize;
    public int bossHP;

    // enemy prefab
    public GameObject enemyPrefab;

    // number of enemies
    public int numEnemies;

    public int killEnemies;

    // Die effect
    public GameObject enemyDieEffect;
    
    public void CreateEnemyWave()
    {
        // calculate number of enemies
        numEnemies = numZ * numX * numY;

        Vector3 startPos = transform.position;

        for (int k = 0; k < numY; k++)
        {
            for (int j = 0; j < numX; j++)
            {
                for (int i = 0; i < numZ; i++)
                {
                    // spawn enemy
                    GameObject newEnemy = Instantiate(enemyPrefab);

                    // set enemy position
                    newEnemy.transform.position = new Vector3(startPos.x + separation * j, startPos.y + separation * k, startPos.z + separation * i);
                    
                }
            }
        }          
    }

    public void CreateBOSSWave()
    {
        // calculate number of enemies
        numEnemies = 1;

        Vector3 startPos = transform.position;

        // // spawn enemy
        GameObject newEnemy = Instantiate(enemyPrefab);

        // // set enemy position
        newEnemy.transform.position = new Vector3(startPos.x + separation * 2, startPos.y + separation * 4, startPos.z + separation * 3);

        newEnemy.GetComponent<EnemyController>().hp = bossHP;
        newEnemy.GetComponent<EnemyController>().speed = 2f;
        newEnemy.GetComponent<EnemyController>().isSplit = true;
        newEnemy.transform.localScale = new Vector3(bossSize, bossSize, bossSize);
    }

    public void KillAll()
    {
        //find all the enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        //iterate through these enemies and destroy them
        for(int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
    }
}
