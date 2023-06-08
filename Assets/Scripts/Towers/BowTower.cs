using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BowTower : Tower
{
    private void Awake()
    {
        data = GameManager.Resource.Load<TowerData>("Data/BowTowerData");
    }
    
}
