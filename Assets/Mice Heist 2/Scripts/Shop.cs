
using UnityEngine;

namespace Towers
{
    public class Shop : MonoBehaviour
    {
        public Tower standardTower;
        public Tower rangedTower;

        TowerPlacement towerPlacement;

        private void Start()
        {
            towerPlacement = TowerPlacement.instance;
        }



        public void SelectStandardTower()
        {
            Debug.Log("Standard Tower Selected");
            towerPlacement.SelectTowerToPlace(standardTower);

        }
        public void SelectRangedTower()
        {
            Debug.Log("Ranged Tower selected");
            towerPlacement.SelectTowerToPlace(rangedTower);
        }
    }
}