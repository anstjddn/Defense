using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildInGameUI : InGameUI
{
    public TowerPlace towerPlace;


    protected override void Awake()
    {
        base.Awake();

        buttons["Blocker"].onClick.AddListener(() => GameManager.UI.CloseInGameUi(this));
        buttons["BowButton"].onClick.AddListener(() => { BulidBowTower(); });
        buttons["CanonButton"].onClick.AddListener(() => { BulidCanonTower(); });
    }
    public void BulidBowTower()
    {
        TowerData bowtowerdata = GameManager.Resource.Load<TowerData>("Data/BowTowerData");
        towerPlace.BuildTower(bowtowerdata);
        GameManager.UI.CloseInGameUi(this);
    }
    public void BulidCanonTower()
    {
        TowerData Canontowerdata = GameManager.Resource.Load<TowerData>("Data/CanonTowerData");
        towerPlace.BuildTower(Canontowerdata);
        GameManager.UI.CloseInGameUi(this);
    }
}
