using UnityEngine;

public class waypoint : MonoBehaviour
{
    public static Transform[] points;
    
    void awake ()
    {
        points = new Transform[transform.childCount];
        for(int i = 0; i < points.Length; int++)
        {
            points[i] = Transform.GetChild(i);
        }
    }
}
