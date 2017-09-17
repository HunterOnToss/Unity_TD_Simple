using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class EnemyMovement : MonoBehaviour {

    private Transform _target;
    private int _wavepointIndex;

    private EnemyController _enemyController;

    void Start()
    {
        _enemyController = this.GetComponent<EnemyController>();
        _target = Waypoints.Points[0].transform;
    }

    void Update()
    {
        _checkIsEndPath();
        MoveToPoints();

        _enemyController.Speed = _enemyController.StartSpeed;
    }

    private void MoveToPoints()
    {
        var dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _enemyController.Speed * Time.deltaTime, Space.World);

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
            _enemyController.IsDie = true;
        }
    }
}
