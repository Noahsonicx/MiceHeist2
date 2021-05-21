using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateWaypoints : MonoBehaviour
{
    public static Transform[] alternateWaypoints;

    private void Awake()
    {
        alternateWaypoints = new Transform[transform.childCount];
        for (int i = 0; i < alternateWaypoints.Length; i++)
        {
            alternateWaypoints[i] =  transform.GetChild(i);
        }
    }

}
