using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour {

    private Transform _target;
    private int _wavepointIndex;
    private int Speed = 0;

    void Start()
    {
        _target = Waypoints.Points[0].transform;
    }

    void Update()
    {
        _checkIsEndPath();
        MoveToPoints();
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
            //_isDie = true;
        }
    }
}
