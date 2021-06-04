using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers
{

    [System.Serializable]
    public class Tower 
    {
        // Tower class holds information for the towers, and then gets set in Shop.cs
        public string towerName;
        public int towerCost = 0;        
        public GameObject towerPrefab;
        
        

    }
}
