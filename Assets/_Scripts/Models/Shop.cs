using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildController _buildManager;

    void Start()
    {
        _buildManager = BuildController.InstanceBuildController;
    }

    public void PurchaseStandardTurret()
    {
        _buildManager.SetTurretToBuild(_buildManager.StandardTurretPrefab);
    }

    public void PurchaseMissileLauncher()
    {
        _buildManager.SetTurretToBuild(_buildManager.MissileLauncherPrefab);
    }
}
