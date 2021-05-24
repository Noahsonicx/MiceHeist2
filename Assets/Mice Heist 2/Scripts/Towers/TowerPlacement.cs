using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
    public class TowerPlacement : MonoBehaviour
    {
        public static TowerPlacement instance;

        private Tower towerToPlace;
        
        [SerializeField] private GameObject towerPrefabCat;
        [SerializeField] private GameObject towerPrefabCatRanged;
        [SerializeField] private GameObject barrierPrefab;
        

               
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
        public void BuildTurretOn(Node node)
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
         /*
        private void OnMouseUp()
        {
            if (CanPlaceTower())
            {

                tower = Instantiate(prefabs[prefabIndex], new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), Quaternion.identity);
                
            }
        }

        public void OnGUI()
        {
            if(GUI.Button(new Rect(20, 20, 20, 20), "add to int"))
            {
                prefabNo++;
                Debug.Log(prefabNo);
            }
        }

        /// <summary>
        /// Checks whether the tower variable is null and if so returns true.
        /// </summary>
        /// <returns></returns>
        private bool CanPlaceTower()
        {
            return tower == null;
        }

        /*
        bool to detect if tower is being placed
          
        which tower prefab did you buy??

        when mouse clicks on a "spot" instantiate chosen tower type there.

        deduct currency from bank

        */

    }
}
