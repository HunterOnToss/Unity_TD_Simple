using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float StartSpeed = 9f;

    [HideInInspector]
    public float Speed;

    public float Health = 119;
    public int Worth = 50;
    public GameObject DeathEffect;
    public bool IsDie;

    void Start()
    {
        Speed = StartSpeed;
    }

    void Update()
    {
        if (IsDie) { Die();}
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;

        if (Health <= 0)
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
        PlayerStats.Lives--;

        var effect = Instantiate(DeathEffect, transform.position, Quaternion.identity);

        Destroy(effect, 5f);
        Destroy(this.gameObject);
    }
}
