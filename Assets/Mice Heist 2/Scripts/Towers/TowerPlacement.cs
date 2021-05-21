using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
    public class TowerPlacement : MonoBehaviour
    {
        [SerializeField] private GameObject towerPrefabCat;
        private GameObject tower;

        private bool placingTower = true;

        private Transform spot;


        private void OnMouseUp()
        {
            if (CanPlaceTower())
            {
                tower = (GameObject)Instantiate(towerPrefabCat, transform.position, Quaternion.identity);
                
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
