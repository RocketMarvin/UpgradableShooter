using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum spawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave
    {
       
        public string name;
        public Transform enemy;
        public int enemyCount;
        public float spawnRate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    public float searchCountdown = 1f;

    private spawnState state = spawnState.COUNTING;

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("no spawnpoints refercned");
        }

    }

    private void Update()
    {
        if (state == spawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
               
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != spawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    public void WaveCompleted()
    {
        Debug.Log("wave completed");
        
        state = spawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("ALL WAVES COMPLETED looping..");
        }

        nextWave++;

    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;  
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                Debug.Log("test");
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log($"Spawning wave {_wave.name}");
        state = spawnState.SPAWNING;

        for (int i = 0; i < _wave.enemyCount; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.spawnRate);
        }

        state = spawnState.WAITING;

        yield break;
    }
     
    public void SpawnEnemy(Transform _enemy)
    {
        Debug.Log($"Spawning Enemy: {_enemy.name}");
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy,_sp.position,_sp.rotation);
    }
}
