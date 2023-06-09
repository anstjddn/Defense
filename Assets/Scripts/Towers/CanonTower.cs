using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CanonTower : Tower
{
    [SerializeField] Transform CanonPoint;
    
    protected override void Awake()
    {
        base.Awake();
        data = GameManager.Resource.Load<TowerData>("Data/CanonTowerData");
    }
    private void OnEnable()                 
    {
     
        StartCoroutine(AttackRoutin());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

  

    public void Attack(EnemyCotroller enemy)
    {
        CanonBall canon = GameManager.Resource.Instantiate<CanonBall>("Tower/CanonBall",CanonPoint.position,CanonPoint.rotation);

        canon.SetTarGet(enemy);
        canon.SetDamage(data.towers[0].damage);
    }
    IEnumerator AttackRoutin()
    {
        while (true)
        {
            if (enemylist.Count > 0)
            {
                Attack(enemylist[0]);
                yield return new WaitForSeconds(data.Towers[0].delay);
            }

            else
            {
                yield return null;
            }
        }

    }

}
