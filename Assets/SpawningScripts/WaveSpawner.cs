using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public enum spawnState { spawning, waiting, counting};

    public GameManager gameManager; 

   [System.Serializable]
    public class Wave
    {
        public string waveName; //to announch approaching wave
        public Transform enemy;
        public int count;
        public float spawnRate;

    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f; //5 seconds

    public float waveCountdown;

    public float timeBetweenSpawn = 1f;

    public float searchCountdown = 1f;

    public spawnState State = spawnState.counting;

    void Start()
    {
        Debug.Log("Round Start");
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No Spawn Points referenced");
        } 

        waveCountdown = timeBetweenWaves;
       
    }

    void Update()
    {
        

        if (State == spawnState.waiting)

        {
            //Debug.Log(EnemyIsAlive());
            if (EnemyIsAlive()==false) //if enemies are not alive
            {
                //begin new round 
                Debug.Log("wave Beaten");
                waveCompleted();

            }
            else //if enemies are still alive
            {
                return; //wait for player to kill the enemies
            }

        }

        if (waveCountdown <= 0)
        {
            if (State != spawnState.spawning)
            {
                //start spawning wave
                StartCoroutine(SpawnWave(waves[nextWave]));

            }
        }
        else
        {
            waveCountdown -= Time.deltaTime; //tick down the time. Keep timer accurate. 
        }
          
    }

    void waveCompleted()
    {
        Debug.Log("Wave Completed");

        waveCountdown = timeBetweenWaves;
        State = spawnState.counting;
        

        if(nextWave + 1 > waves.Length - 1)
        {
            PlayerPrefs.SetInt("levelReached", 1);
            //PlayerPrefs.SetInt("levelReached", PlayerPrefs.GetInt("levelReached")+1); //increases levels beaten
            Debug.Log(PlayerPrefs.GetInt("levelReached")+"levels beaten");

            gameManager.LoadLevel(6); //go to win screen
        }
        else
        {
            nextWave++; 
        }
        
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;//ticks down searchCountdown
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

       
        return true;
    }


    IEnumerator SpawnWave (Wave _wave)
    {

        Debug.Log("Spawning wave:" + _wave.waveName);
        State = spawnState.spawning;
        
        //start spawning
        for (int i =0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(timeBetweenSpawn / _wave.spawnRate);
        }

        //State = spawnState.counting;

        //while(waveCountdown>=)


        State = spawnState.waiting; 
        //wait for player to kill enemies

        yield break; //must be ending point
    }

   

    void SpawnEnemy(Transform _Enemy)
    {

        Debug.Log("Spawning Enemy:" + _Enemy.name);
        //spawn enemy
       
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)]; //get a random spawnpoint. Must have at least one spawnpoint
        Instantiate(_Enemy, _sp.position, _sp.rotation);
        
    }


}
