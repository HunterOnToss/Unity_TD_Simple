using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject UI;

    private TowerFrame _target;

    public void SetTarget(TowerFrame target)
    {
        _target = target;

        transform.position = _target.GetBuildPosition();

        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }
}
