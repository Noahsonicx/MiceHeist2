
using UnityEngine;

namespace Towers
{
    public class Shop : MonoBehaviour
    {
        [Header("Tower Details")]
        public Tower standardTower;
        public Tower rangedTower;

        TowerPlacement towerPlacement;

        private void Start()
        {
            // Setting the instance to the local vaiable
            towerPlacement = TowerPlacement.instance;
        }


        /// <summary>
        /// Sets the Tower to place as the Standard Tower
        /// </summary>
        public void SelectStandardTower()
        {
            Debug.Log("Standard Tower Selected");
            // Passes the Standard Tower into towerPlacement.SelectTowerToPlace();
            towerPlacement.SelectTowerToPlace(standardTower);

        }
        /// <summary>
        /// Sets the Tower to place as the Ranged Tower
        /// </summary>
        public void SelectRangedTower()
        {
            Debug.Log("Ranged Tower selected");
            // Passes the Ranged Tower into towerPlacement.SelectTowerToPlace();
            towerPlacement.SelectTowerToPlace(rangedTower);
        }
    }
}