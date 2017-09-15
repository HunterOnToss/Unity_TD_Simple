using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFrame : MonoBehaviour
{
    public Color HoverColor;

    private Renderer _renderer;
    private Color _startColor;
    private GameObject _turret;

    void Start()
    {
        _renderer = this.GetComponent<Renderer>();
        _startColor = _renderer.material.color;
    }

    private void OnMouseDown()
    {
        if (_turret != null)
        {
            Debug.Log("Can't build there!");
            return;
        }

        var turretToBuild = BuildController.InstanceBuildController.GetTurretToBuild();
        _turret = Instantiate(turretToBuild, this.transform.position, this.transform.rotation);
    }

    private void OnMouseEnter()
    {
        _renderer.material.color = HoverColor;
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }
}
