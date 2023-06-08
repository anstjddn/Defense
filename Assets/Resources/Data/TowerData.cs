using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TowerData;

[CreateAssetMenu(fileName ="TowerData", menuName ="Data/Tower")]   
// 파일안에 우클릭햇을때 추가할때 메뉴를 만들수있따.
public class TowerData : ScriptableObject
{
   [SerializeField] public Towerinfo[] towers;


    [Serializable]
    public class Towerinfo
    {
        public Tower tower;

        public int damage;
        public int range;
        public float delay;
        public float buildTime;
        public int buildCost;
        public int sellcost;

    }

}
