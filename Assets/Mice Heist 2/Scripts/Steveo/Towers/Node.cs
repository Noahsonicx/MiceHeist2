using UnityEngine.EventSystems;
using UnityEngine;

namespace Towers
{ 
public class Node : MonoBehaviour
{
    [Header("Node Colors")]
    public Color hoverColor;
    public Color notEnoughColor;
    private Color startColor;
    
    [Header("Prefab Placement Offset")]
    public Vector3 posOffset;

    [Header("Optional Start Tower")]
    public GameObject tower;


    private Renderer rend;

    TowerPlacement towerPlacement;

    private void Start()
    {
        towerPlacement = TowerPlacement.instance;   // Sets the instance to local vaiable
        rend = GetComponent<Renderer>();            // Gets the node renderer
        startColor = rend.material.color;           // Sets the node Start color
            
    }

    /// <summary>
    /// Gets the position for the Tower on the node, including the offset.
    /// </summary>
    /// <returns>The build position</returns>
    public Vector3 GetBuildPosition()
    {
        return transform.position + posOffset;
    }

    /// <summary>
    /// Everything that happens on a mouse click
    /// </summary>
    private void OnMouseDown()
    {
            // This checks if the mouse has clicked on a UI element, if so, it returns.
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        // If false for CanBuild then return.
        if (!towerPlacement.CanBuild)
            return;

        // If tower variable contains something, Can't build and return.
        if (tower != null)
        {
            Debug.Log("Can't build there"); // display on screen UI??
            return;
        }

        // Sends this node through as the argument for BuildTowerOn().
        towerPlacement.BuildTowerOn(this);

            


    }

    private void OnMouseEnter()
    {            
            // This checks if the mouse is over a UI element, if so, returns.
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!towerPlacement.CanBuild) // Checks if the node contains a tower, if not, can build.
            return;
        if (towerPlacement.HasMoney)
        {
                // If player has enough moeny to build and can build, sets the node color to the hover color
            rend.material.color = hoverColor;
        }
        else
        {
                // Sets the node to the notEnoughColor if the player doesn't have enough money to build on it
            rend.material.color = notEnoughColor;
        }
    }

    private void OnMouseExit()
    {
        // Sets the node color back to the start color
        rend.material.color = startColor;
    }
}
}