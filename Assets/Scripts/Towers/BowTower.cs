using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowTower : Tower
{
    private void Awake()
    {
        data = GameManager.Resource.Load<TowerData>("Data/BowTowerData");
    }
}
