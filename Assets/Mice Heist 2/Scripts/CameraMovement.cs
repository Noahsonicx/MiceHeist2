using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float minY = 10;
    public float maxY = 80;

    
    // Update is called once per frame
    void Update()
    {
        /// Ability to use moue scroll to zoom in and out of game area
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
