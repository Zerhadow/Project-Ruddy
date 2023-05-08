using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSystem : MonoBehaviour {
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
    private int highestWave = 0;

    public TMP_Text waveText;
    // public TMP_Text enemiesLeftText;
    private int waveCount;
    int totalEnemies;
    // GameObject waveIndicator;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    PlayerController player;

    public AudioSource winSound;

    void Awake() {
        waveCount = nextWave + 1;
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        // enemiesLeftText = GameObject.Find("EnemiesLeftText").GetComponent<TMP_Text>();
        waveText.text = "Wave: " + waveCount.ToString();
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
        // Debug.Log("Enemies left: " + totalEnemies);
        // enemiesLeftText.text = "Enemies left: " + totalEnemies.ToString();
    }

    void WaveCompleted() {
        //begin new round
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1) {
            Debug.Log("Completed all waves");
            winSound.Play();
            player.BeatGame();
        } else {
            nextWave++;
            waveCount = nextWave + 1;
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

        waveText.text = "Wave: " + waveCount.ToString();

        for(int i = 0; i < wave.enemies.Length; i++) {
            SpawnEnemy(wave.enemy[0], i);
            yield return new WaitForSeconds(1/wave.rate);
        }        

        // enemiesLeftText.text = "Enemies Left: " + totalEnemies.ToString();

        state = SpawnState.WAITING;
        // player.waveIndicator.SetActive(false);

        yield break;
    }

    void SpawnEnemy(Transform _enemy, int idx) {
        Debug.Log("Spawning Enemy: " + _enemy.name);

        Transform randomSpawnPoint = spawnPoints[idx];
        Instantiate(_enemy, randomSpawnPoint.position, randomSpawnPoint.rotation);
    }

    void GetTotalEnemies() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        totalEnemies = enemies.Length;
    }
}