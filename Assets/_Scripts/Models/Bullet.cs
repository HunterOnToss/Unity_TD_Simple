using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;

    public float ExplosionRadius;
    public float Speed = 75f;
    public GameObject ImpactEffect;

	void Update ()
    {
        if (_target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        var dir = _target.transform.position - this.transform.position;
        var distanceThisFrame = Speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        this.transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        this.transform.LookAt(_target);

    }

    private void HitTarget()
    {
        var effect = Instantiate(ImpactEffect, this.transform.position, this.transform.rotation);
        Destroy(effect, 2f);

        if (ExplosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(_target);
        }

        Destroy(this.gameObject);
    }

    private void Explode()
    {
        var colliders = Physics.OverlapSphere(this.transform.position, ExplosionRadius);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);
            }
        }
    }

    private static void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    public void Seek(Transform target)
    {
        _target = target;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, ExplosionRadius);
    }
}
