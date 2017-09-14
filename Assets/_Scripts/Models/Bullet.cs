using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;

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

    }

    private void HitTarget()
    {
        var effect = Instantiate(ImpactEffect, this.transform.position, this.transform.rotation);
        Destroy(effect, 2f);

        Destroy(_target.gameObject);
        Destroy(this.gameObject);
    }

    public void Seek(Transform target)
    {
        _target = target;
    }
}
