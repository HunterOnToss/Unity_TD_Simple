using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float StartSpeed = 9f;

    [HideInInspector]
    public float Speed;

    public float StartHealth = 119;
    private float _currentHealth;
   
    public int Worth = 50;
    public GameObject DeathEffect;
    public bool IsDead;

    [Header("Unity Stuff")]
    public Image HealthBar;

    void Start()
    {
        _currentHealth = StartHealth;
        Speed = StartSpeed;
    }

    void Update()
    {
        if (IsDead) { Die();}
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        HealthBar.fillAmount = _currentHealth / StartHealth;

        if (_currentHealth <= 0)
        {
            IsDead = true;
        }
    }

    public void Slow(float slowAmount)
    {
        Speed = StartSpeed * (1f - slowAmount);
    }

    private void Die()
    {
        WaveSpawner.EnemiesAlive--;
        PlayerStats.Money += Worth;

        var effect = Instantiate(DeathEffect, transform.position, Quaternion.identity);

        Destroy(effect, 5f);
        Destroy(this.gameObject);
    }
}
