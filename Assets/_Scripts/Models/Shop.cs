using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint StandardTurret;
    public TurretBlueprint MissileTurret;

    private BuildController _buildManager;

    void Start()
    {
        _buildManager = BuildController.InstanceBuildController;
    }

    public void SelectStandardTurret()
    {
        _buildManager.SelectTurretToBuild(StandardTurret);
    }

    public void SelectMissileLauncher()
    {
        _buildManager.SelectTurretToBuild(MissileTurret);
    }
}
