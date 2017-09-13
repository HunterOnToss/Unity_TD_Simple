using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{

    public static List<GameObject> Points;

    private void Awake()
    {
        Points = new List<GameObject>();

        for (var i = 0; i < this.transform.childCount; i++)
        {
            Points.Add(this.transform.GetChild(i).gameObject);
        }
    }

    private void Start()
    {
        Debug.Log(Points[Points.Count-1]);
    }
}
