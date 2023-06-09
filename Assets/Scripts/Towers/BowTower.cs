using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class BowTower : Tower
{
    [SerializeField] Transform Bow;
    [SerializeField] Transform ArrowPoint;
    protected override void Awake()
    {
        base.Awake();
        data = GameManager.Resource.Load<TowerData>("Data/BowTowerData");
    }

    private void OnEnable()                 //코루틴 계속 실시간으로 업데이트에 넣는게 낫지않나?
                                            // 하지만 기능이 비대해질경우 업데이트에 넣는걸 주의해야한다
                                            // 따라서 대안으로 enable에서 disable로 설정한다
    {
        StartCoroutine(LookRoutin());
        StartCoroutine(AttackRoutin());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator LookRoutin()
    {
        while (true)
        {
            if (enemylist.Count > 0)
            {
                Bow.LookAt(enemylist[0].transform.position);
            }
            yield return null;
        }
    }

    public void Attack(EnemyCotroller enemy)
    {
        Arrow arrow = GameManager.Resource.Instantiate<Arrow>("Tower/Arrow", ArrowPoint.position, ArrowPoint.rotation);
        arrow.SetTarGet(enemy);
        arrow.SetDamage(data.towers[0].damage);
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
