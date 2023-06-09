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

    private void OnEnable()                 //�ڷ�ƾ ��� �ǽð����� ������Ʈ�� �ִ°� �����ʳ�?
                                            // ������ ����� ���������� ������Ʈ�� �ִ°� �����ؾ��Ѵ�
                                            // ���� ������� enable���� disable�� �����Ѵ�
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
