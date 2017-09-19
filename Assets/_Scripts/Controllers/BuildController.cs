using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    public static BuildController InstanceBuildController;
    public GameObject BuildEffect;
    public GameObject SellEffect;
    public NodeUI SelectedNodeUi;

    private TurretBlueprint _turretToBuild;
    private TowerFrame _selectedTowerFrame;

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

        DeselectNode();
    }
    
    public void SelectTowerFrame(TowerFrame towerFrame)
    {
        if (_selectedTowerFrame == towerFrame)
        {
            DeselectNode();
            return;
        }

        _selectedTowerFrame = towerFrame;
        _turretToBuild = null;

        SelectedNodeUi.SetTarget(_selectedTowerFrame);
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return _turretToBuild;
    }

    public void DeselectNode()
    {
        _selectedTowerFrame = null;
        SelectedNodeUi.Hide();
    }
}
