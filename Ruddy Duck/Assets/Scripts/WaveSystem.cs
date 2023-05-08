using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour {
    public enum SpawnState {SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave {
        public string name;
        [Header("Enemy prefabs")]
        public Transform[] enemy;
        [Header("Number of enemies per type")]
        public int[] enemies;
        public float rate; //amount of time in between mob spawns
    }

    public Wave[] waves;
    private int nextWave = 0;
    public int highestWave = 0;

    public TMP_Text valueText;
    public TMP_Text enemiesLeftText;
    public int waveCount;
    int totalEnemies;
    // GameObject waveIndicator;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    PlayerController player;

    GameObject directionalLight;

    void Awake() {
        waveCount = nextWave + 1;
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        valueText = GameObject.Find("WaveCountText").GetComponent<TMP_Text>();
        enemiesLeftText = GameObject.Find("EnemiesLeftText").GetComponent<TMP_Text>();
        valueText.text = "Wave: " + waveCount.ToString();
        // waveIndicator = GameObject.Find("WaveIndicator"); 
    }

    void Start() {
        if(spawnPoints.Length == 0) {
            Debug.Log("No spawn points referenced");
        }

        waveCountdown = timeBetweenWaves;
    }

    void Update() {
        if(state == SpawnState.WAITING) {
            //check if enemies are still alive
            if(!EnemyIsAlive()) {
                Debug.Log("Wave completed");
                WaveCompleted();
            } else {
                return;
            }
        }

        if(waveCountdown <= 0) {
            if(state != SpawnState.SPAWNING) {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        } else {
            waveCountdown -=Time.deltaTime;
        }

        GetTotalEnemies();
    }

    void FixedUpdate() {

        waveCount = nextWave + 1;
        // Debug.Log("Enemies left: " + totalEnemies);
        enemiesLeftText.text = "Enemies left: " + totalEnemies.ToString();
    }

    void WaveCompleted() {
        //begin new round
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1) {
            Debug.Log("Completed all waves");
            player.BeatGame();
        } else {
            nextWave++;
            if(nextWave > highestWave)
                highestWave = nextWave;
        }
    }

    bool EnemyIsAlive() {
        searchCountdown -= Time.deltaTime;

        if(searchCountdown <= 0f) {
            if(GameObject.FindGameObjectWithTag("Enemy") == null) {
                Debug.Log("No enemies alive");
                return false;
            }

            searchCountdown = 1f;
        }        

        return true;
    }

    IEnumerator SpawnWave(Wave wave) {
        Debug.Log("Spawning Wave: " + wave.name);
        state = SpawnState.SPAWNING;

        // player.waveIndicator.SetActive(true);

        valueText.text = "Wave: " + waveCount.ToString();

        if(wave.enemy.Length == wave.enemies.Length) {
            for(int i = 0; i < wave.enemy.Length; i++) {
                for(int j = 0; j < wave.enemies[i]; j++) {
                    SpawnEnemy(wave.enemy[i]);
                    yield return new WaitForSeconds(1/wave.rate);
                }
            }
        } else {
            Debug.Log("Enemy and enemy count arrays are not the same length");
        }

        enemiesLeftText.text = "Enemies Left: " + totalEnemies.ToString();

        state = SpawnState.WAITING;
        // player.waveIndicator.SetActive(false);

        yield break;
    }

    void SpawnEnemy(Transform _enemy) {
        // Debug.Log("Spawning Enemy: " + _enemy.name);

        //spawn enemy; change from random
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, randomSpawnPoint.position, randomSpawnPoint.rotation);
    }

    void despawnAllEnemies() {
        // Debug.Log("Despawning all enemies");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies) {
            Destroy(enemy);
        }
    }

    void GetTotalEnemies() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        totalEnemies = enemies.Length;
    }

    private void OnDrawGizmos() {
        //draw spawn points
        Gizmos.color = Color.red;
        foreach(Transform spawnPoint in spawnPoints) {
            Gizmos.DrawWireSphere(spawnPoint.position, 1f);
        }
    }

    // public void Destroy {
    //     Destroy(gameObject);
    // }
}