using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
    public class TowerPlacement : MonoBehaviour
    {
        public static TowerPlacement instance;

        private Tower towerToPlace;

        //public GameObject buildEffect;

        public bool CanBuild { get { return towerToPlace != null; } }
        public bool HasMoney { get { return PlayerStats.Money >= towerToPlace.towerCost; } }

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("More than one TowerPlacement in scene");
                return;
            }
            instance = this;
        }

        public void SelectTowerToPlace(Tower tower)
        {
            towerToPlace = tower;
        }
        public void BuildTowerOn(Node node)
        {
            if (PlayerStats.Money < towerToPlace.towerCost)
            {
                Debug.Log("Not enogh money");
                return;
            }
            PlayerStats.Money -= towerToPlace.towerCost;

            GameObject tower = (GameObject)Instantiate(towerToPlace.towerPrefab, node.GetBuildPosition(), Quaternion.identity);
            node.tower = tower;

            //GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
            //Destroy(effect, 5f);

            Debug.Log("Turret built. money left " + PlayerStats.Money);
        }
         

    }
}
