﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerFrame : MonoBehaviour
{
    public Color HoverColor;

    [Header("Optional")]
    public GameObject Turret;

    private Renderer _renderer;
    private Color _startColor;
    private BuildController _buildManager;

    void Start()
    {
        _renderer = this.GetComponent<Renderer>();
        _startColor = _renderer.material.color;
        _buildManager = BuildController.InstanceBuildController;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) { return; }
        if (!_buildManager.CanBuild) { return;}
        if (Turret != null){ return; }

        _buildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) { return; }
        if (!_buildManager.CanBuild) { return; }
        _renderer.material.color = HoverColor;
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }
}
