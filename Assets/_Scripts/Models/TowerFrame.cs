using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerFrame : MonoBehaviour
{
    public Color HoverColor;
    public Color NotEnoughMoneyColor = Color.red;

    //[Header("Optional")]
    [HideInInspector] public GameObject Turret;
    [HideInInspector] public TurretBlueprint TurretBlueprintForFrame;
    [HideInInspector] public bool IsUpgraded;

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

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < TurretBlueprintForFrame.UpgradeCost)
        {
            Debug.Log("Not enough Money to upgrade");
            return;
        }

        PlayerStats.Money -= TurretBlueprintForFrame.UpgradeCost;

        Destroy(Turret);

        var turret = Instantiate(TurretBlueprintForFrame.UpgradePrefab, GetBuildPosition(), Quaternion.identity);
        Turret = turret;

        var effect = Instantiate(_buildManager.BuildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        IsUpgraded = true;
    }

    private void BuildTurret(TurretBlueprint turretToBuild)
    {
        if (PlayerStats.Money < turretToBuild.Cost)
        {
            Debug.Log("Not enough Money");
            return;
        }

        PlayerStats.Money -= turretToBuild.Cost;

        var turret = Instantiate(turretToBuild.Prefab, GetBuildPosition(), Quaternion.identity);
        Turret = turret;

        TurretBlueprintForFrame = turretToBuild;

        var effect = Instantiate(_buildManager.BuildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) { return; }
        if (Turret != null)
        {
            _buildManager.SelectTowerFrame(this); 
            return;
        }
        if (!_buildManager.CanBuild) { return; }

        BuildTurret(_buildManager.GetTurretToBuild());
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) { return; }
        if (!_buildManager.CanBuild) { return; }

        if (_buildManager.HasMoney)
        {
            _renderer.material.color = HoverColor;
        }
        else
        {
            _renderer.material.color = NotEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }
}
