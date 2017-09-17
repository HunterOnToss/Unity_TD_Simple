using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    public static BuildController InstanceBuildController;
    public GameObject BuildEffect;

    private TurretBlueprint _turretToBuild;

    public bool CanBuild { get { return _turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= _turretToBuild.Cost; } }

    void Awake()
    {
        if (InstanceBuildController != null)
        {
            Debug.LogError("More than once BuildController in scene!");
        }

        InstanceBuildController = this;
    }
    
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        _turretToBuild = turret;
    }

    public void BuildTurretOn(TowerFrame towerFrame)
    {
        if (PlayerStats.Money < _turretToBuild.Cost)
        {
            Debug.Log("Not enough Money");
            return;
        }

        PlayerStats.Money -= _turretToBuild.Cost;

        var turret = Instantiate(_turretToBuild.Prefab, towerFrame.GetBuildPosition(), Quaternion.identity);
        towerFrame.Turret = turret;

        var effect = Instantiate(BuildEffect, towerFrame.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Debug.Log("Turret build! money left:" + PlayerStats.Money);
    }
}
