using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyController : MonoBehaviour {

    public float Speed = 9f;
    public int Health = 119;
    public int ValueForDie = 50;
    public GameObject DeathEffect;

    private Transform _target;
    private int _wavepointIndex;
    private bool _isDie;

    void Start()
    {
        _target = Waypoints.Points[0].transform;
    }

    void Update()
    {
        _checkIsEndPath();

        if (_isDie) { Die();}
        else { MoveToPoints();}
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;

        if (Health <= 0)
        {
            _isDie = true;
        }
    }

    private void MoveToPoints()
    {
        var dir = _target.position - transform.position;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        _wavepointIndex++;
        if (_wavepointIndex < Waypoints.Points.Count)
        {
            _target = Waypoints.Points[_wavepointIndex].transform;
        }
    }

    private void _checkIsEndPath()
    {
        if (_wavepointIndex >= Waypoints.Points.Count)
        {
            _isDie = true;
        }
    }

    private void Die()
    {
        PlayerStats.Money += ValueForDie;
        PlayerStats.Lives--;

        var effect = Instantiate(DeathEffect, transform.position, Quaternion.identity);

        Destroy(effect, 5f);
        Destroy(this.gameObject);
    }
}
