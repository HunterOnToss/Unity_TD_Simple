using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform EnemyPrefab;
    public Transform SpawnLocation;
    public float TimeBetweenWaves = 5f;
    public Text WaveCountDownText;

    private float _countdown = 2f;
    private int _waveIndex;

    void Update()
    {
        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = TimeBetweenWaves;
        }

        _countdown -= Time.deltaTime;
        _countdown = Mathf.Clamp(_countdown, 0f, Mathf.Infinity);

        //WaveCountDownText.text = Mathf.Floor(_countdown).ToString();
        WaveCountDownText.text = string.Format("{0:00.00}", _countdown);
    }

    private IEnumerator SpawnWave()
    {
        _waveIndex++;

        for (var i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, SpawnLocation.position, SpawnLocation.rotation);
    }
}
