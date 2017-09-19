using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject UI;
    public Text SellAmount;
    public Text UpgradeCost;
    public Button UpgradeButton;

    private TowerFrame _target;

    public void SetTarget(TowerFrame target)
    {
        _target = target;

        if (!_target.IsUpgraded)
        {
            UpgradeCost.text = "$ " + _target.TurretBlueprintForFrame.UpgradeCost;
            UpgradeButton.interactable = true;
        }
        else
        {
            UpgradeCost.text = "Done!";
            UpgradeButton.interactable = false;
        }

        SellAmount.text = "$ " + _target.TurretBlueprintForFrame.GetSellAmount();
        transform.position = _target.GetBuildPosition();

        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        _target.UpgradeTurret();
        BuildController.InstanceBuildController.DeselectNode();
    }

    public void Sell()
    {
        _target.SellTurret();
        BuildController.InstanceBuildController.DeselectNode();
    }

}
