using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{

    public static Transform[] Points;

    private void Awake()
    {
        Points = new Transform[this.transform.childCount];

        for (var i = 0; i < Points.Length; i++)
        {
            Points[i] = this.transform.GetChild(i);
        }
    }

    private void Start()
    {
        Debug.Log(Points.Length);
    }
}
