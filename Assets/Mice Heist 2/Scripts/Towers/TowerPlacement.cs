using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
    public class TowerPlacement : MonoBehaviour
    {
        public static TowerPlacement instance;

        private Tower towerToPlace;

        [Header("Build Effect")]
        public GameObject buildEffect; //The effect that happens when building a tower

        // Properties to call from other scripts
        public bool CanBuild { get { return towerToPlace != null; } }
        public bool HasMoney { get { return PlayerStats.Money >= towerToPlace.towerCost; } }

        private void Awake()
        {
            // Creating the check for a singleton
            if (instance != null)
            {
                Debug.LogError("More than one TowerPlacement in scene");
                return;
            }
            instance = this;
        }

        /// <summary>
        /// Sets the chosen tower as the tower to place on the node
        /// </summary>
        /// <param name="tower"></param>
        public void SelectTowerToPlace(Tower tower)
        {
            towerToPlace = tower;
        }

        /// <summary>
        /// Takes in the chosen node and builds the chosen tower on it
        /// </summary>
        /// <param name="node">Node</param>
        public void BuildTowerOn(Node node)
        {
            // Check the player can afford the tower, if not return.
            if (PlayerStats.Money < towerToPlace.towerCost)
            {
                Debug.Log("Not enogh money");
                return;
            }
            // Subtract the cost of the tower from the money variable
            PlayerStats.Money -= towerToPlace.towerCost;

            // Instantiate the tower on the node and set the nodes .tower
            GameObject tower = (GameObject)Instantiate(towerToPlace.towerPrefab, node.GetBuildPosition(), Quaternion.identity);
            node.tower = tower;

            // Instantiate the build effect and then destroy to clean up the scene
            GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 5f);

            Debug.Log("Turret built. money left " + PlayerStats.Money);
        }
         

    }
}
