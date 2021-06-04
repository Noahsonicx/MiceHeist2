using UnityEngine;

public class waypoint : MonoBehaviour
{
    public static Transform[] points;
    
    private void Awake()
    {
        // Gets the waypoints that are children of the object the script is attached too.
        points = new Transform[transform.childCount];

        for(int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
