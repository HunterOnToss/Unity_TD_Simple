using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyController : MonoBehaviour {

    public float Speed = 9f;
    public float Health = 119;
    public int Worth = 50;
    public GameObject DeathEffect;

    private bool _isDie;

    void Update()
    {
        if (_isDie) { Die();}
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;

        if (Health <= 0)
        {
            _isDie = true;
        }
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
