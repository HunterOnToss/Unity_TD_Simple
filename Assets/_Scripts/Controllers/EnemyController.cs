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
    public bool IsDie;

    [Header("Unity Stuff")]
    public Image HealthBar;

    void Start()
    {
        _currentHealth = StartHealth;
        Speed = StartSpeed;
    }

    void Update()
    {
        if (IsDie) { Die();}
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        HealthBar.fillAmount = _currentHealth / StartHealth;

        if (_currentHealth <= 0)
        {
            IsDie = true;
        }
    }

    public void Slow(float slowAmount)
    {
        Speed = StartSpeed * (1f - slowAmount);
    }

    private void Die()
    {
        PlayerStats.Money += Worth;

        var effect = Instantiate(DeathEffect, transform.position, Quaternion.identity);

        Destroy(effect, 5f);
        Destroy(this.gameObject);
    }
}
