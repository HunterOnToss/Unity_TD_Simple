using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    public static BuildController InstanceBuildController;
    public GameObject StandardTurretPrefab;

    private GameObject _turretToBuild;

    void Awake()
    {
        if (InstanceBuildController != null)
        {
            Debug.LogError("More than once BuildController in scene!");
        }

        InstanceBuildController = this;
    }

    void Start()
    {
        _turretToBuild = StandardTurretPrefab;
    }

    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }

}
