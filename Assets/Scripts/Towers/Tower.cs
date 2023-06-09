using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour
{
    protected TowerData data;

    protected List<EnemyCotroller> enemylist;

    protected virtual void Awake()
    {
        enemylist = new List<EnemyCotroller>();
    }
    public void AddEnemey(EnemyCotroller enemy)
    {
        enemylist.Add(enemy);
    }
    public void ReMoveEnemey(EnemyCotroller enemy)
    {
        enemylist.Remove(enemy);
    }
}
