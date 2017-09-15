using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    public static BuildController InstanceBuildController;
    public GameObject StandardTurretPrefab;
    public GameObject AnotherTurretPrefab;

    private GameObject _turretToBuild;

    void Awake()
    {
        if (InstanceBuildController != null)
        {
            Debug.LogError("More than once BuildController in scene!");
        }

        InstanceBuildController = this;
    }

    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        _turretToBuild = turret;
    }

}
