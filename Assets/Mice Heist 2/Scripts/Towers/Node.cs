using UnityEngine.EventSystems;
using UnityEngine;

namespace Towers
{ 
public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;
    public Color notEnoughColor;

    public Vector3 posOffset;

    [Header("Optional")]
    public GameObject tower;


    private Renderer rend;

    TowerPlacement towerPlacement;

    private void Start()
    {
        towerPlacement = TowerPlacement.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
            Debug.Log("has started");
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + posOffset;
    }

    private void OnMouseDown()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!towerPlacement.CanBuild)
            return;

        if (tower != null)
        {
            Debug.Log("Can't build there"); // display on screen
            return;
        }

        towerPlacement.BuildTurretOn(this);

            Debug.Log("mouse clicked");


    }

    private void OnMouseEnter()
    {
            Debug.Log("mouse has entered");
            
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!towerPlacement.CanBuild)
            return;
        if (towerPlacement.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
}