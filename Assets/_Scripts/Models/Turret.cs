using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform _target;
    private EnemyController _targetEnemy;
      
    [Header("General")]
    public float Range = 15f;

    [Header("Use Bullets (default)")]
    public GameObject BulletPrefab;
    public float FireRate = 1f;
    private float _fireCountdown;

    [Header("Use Laser")]
    public bool UseLaser;
    public int DamageOverTime = 30;
    public LineRenderer LaserLineRenderer;
    public ParticleSystem ImpactEffect;
    public Light LaserImpactEffectLight;
    public float SlowAmount = 0.5f;
    
    [Header("Unity Setup Fields")]
    public string EnemyTag = "Enemy";
    public Transform PartToRotate;
    public float TurnSpeed = 10f;
    public Transform FirePoint;

	void Start ()
    {
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
	void Update ()
    {
        if (_target == null)
        {
            if (UseLaser)
            {
                if (LaserLineRenderer.enabled)
                {
                    LaserLineRenderer.enabled = false;
                    ImpactEffect.Stop();
                    LaserImpactEffectLight.enabled = false;
                }

            }
            return;
        }
        

        LockOnTarget();

        if (UseLaser)
        {
            Laser();
        }
        else
        {
            MakeShot();
        }
    }

    private void Laser()
    {
        _targetEnemy.TakeDamage(DamageOverTime * Time.deltaTime);
        _targetEnemy.Slow(SlowAmount);

        if (!LaserLineRenderer.enabled)
        {
            LaserLineRenderer.enabled = true;
            ImpactEffect.Play();
            LaserImpactEffectLight.enabled = true;
        }

        LaserLineRenderer.SetPosition(0, FirePoint.position);
        LaserLineRenderer.SetPosition(1, _target.position);

        var dir = FirePoint.position - _target.position;
        ImpactEffect.transform.position = _target.position + dir.normalized;
        ImpactEffect.transform.rotation = Quaternion.LookRotation(dir);
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

    private void LockOnTarget()
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
            _targetEnemy = nearestEnemy.GetComponent<EnemyController>();
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
