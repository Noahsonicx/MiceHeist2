using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
    public class TowerPlacement : MonoBehaviour
    {
        [SerializeField] private GameObject towerPrefabCat;
        [SerializeField] private GameObject towerPrefabCatRanged;
        [SerializeField] private GameObject barrierPrefab;
        private GameObject tower;

        [SerializeField] private List<GameObject> prefabs = new List<GameObject>();
        [SerializeField] private int prefabNo;
        private int prefabIndex;

        private void Update()
        {
            prefabIndex = prefabNo;
        }

        private void OnMouseUp()
        {
            if (CanPlaceTower())
            {

                tower = Instantiate(prefabs[prefabIndex], new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), Quaternion.identity);
                
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
