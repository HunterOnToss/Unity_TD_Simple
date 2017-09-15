using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerFrame : MonoBehaviour
{
    public Color HoverColor;

    private Renderer _renderer;
    private Color _startColor;
    private GameObject _turret;
    private BuildController _buildManager;

    void Start()
    {
        _renderer = this.GetComponent<Renderer>();
        _startColor = _renderer.material.color;
        _buildManager = BuildController.InstanceBuildController;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) { return; }
        if (_buildManager.GetTurretToBuild() == null) { return;}
        if (_turret != null){ return; }

        var turretToBuild = _buildManager.GetTurretToBuild();
        _turret = Instantiate(turretToBuild, this.transform.position, this.transform.rotation);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) { return; }
        if (_buildManager.GetTurretToBuild() == null) { return; }
        _renderer.material.color = HoverColor;
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }
}
