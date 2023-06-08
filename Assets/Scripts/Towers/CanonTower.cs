using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanonTower : Tower
{
    private void Awake()
    {
        data = GameManager.Resource.Load<TowerData>("Data/CanonTowerData");
    
    }

}
