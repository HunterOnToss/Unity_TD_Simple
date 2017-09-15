using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform _target;
      
    [Header("Attributes")]
    public float Range = 15f;
    public float FireRate = 1f;
    private float _fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string EnemyTag = "Enemy";
    public Transform PartToRotate;
    public float TurnSpeed = 10f;

    public GameObject BulletPrefab;
    public Transform FirePoint;

	void Start ()
    {
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
	void Update ()
    {
		if (_target == null) return;

        MakeRotationToTarget();
        MakeShot();
    }

    private void MakeShot()
    {
        if (_fireCountdown <= 0)
        {
            Shot();
            _fireCountdown = 1f / FireRate;
        }

        _fireCountdown -= Time.deltaTime;
    }

    private void Shot()
    {
        var bulletGameObject = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        var bullet = bulletGameObject.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(_target);
        }
        
    }

    private void MakeRotationToTarget()
    {
        var dir = _target.position - transform.position;
        var lookRotation = Quaternion.LookRotation(dir);
        //var rotation = lookRotation.eulerAngles;
        var rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * TurnSpeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);  
    }

    private void UpdateTarget()
    {
        var enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        var shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            var distanceToEnemy = Vector3.Distance(this.transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= Range)
        {
            _target = nearestEnemy.transform;
        }
        else
        {
            _target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
