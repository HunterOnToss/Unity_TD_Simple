using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive;

    public Wave[] Waves;
    public GameController TdGameController;
    public Transform SpawnLocation;
    public float TimeBetweenWaves = 5f;
    public Text WaveCountDownText;

    private float _countdown = 5f;
    private int _waveIndex;

    void Update()
    {
        if (EnemiesAlive > 0) { return; }

        if (_waveIndex == Waves.Length)
        {
            TdGameController.WinLevel();
            this.enabled = false;
        }

        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = TimeBetweenWaves;
            return;
        }

        _countdown -= Time.deltaTime;
        _countdown = Mathf.Clamp(_countdown, 0f, Mathf.Infinity);

        WaveCountDownText.text = string.Format("{0:00.00}", _countdown);
    }

    private IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        var wave = Waves[_waveIndex];
        EnemiesAlive = wave.EnemyCount;

        for (var i = 0; i < wave.EnemyCount; i++)
        {
            SpawnEnemy(wave.EnemyPrefab);
            yield return new WaitForSeconds(1f / wave.RateBetweenSpawn);
        }

        _waveIndex++;

    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, SpawnLocation.position, SpawnLocation.rotation);
    }

}
