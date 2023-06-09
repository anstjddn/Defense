using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackRange : MonoBehaviour
{
    public Tower tower;
    public LayerMask enemyMask;
    //처음에 때리는거 플랫포머 할때 최단거리 비교로 할려고했는데 그러면 연산량이 너무 많아서 트리거 충돌체 쓰는게 편하다

   public UnityEvent<EnemyCotroller> OnInRangeEnemey;
   public UnityEvent<EnemyCotroller> OnOutRangeEnemey;

    private void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.layer == enemyMask)  이거 돌리면 안맞음 레이어랑 게임마스트 숫자가 다르다 why? 레이어마스크는 비트연산으로해서 
        //레이어 1증가할때마다 2의제곱끼리 증가한다.
        if (enemyMask.IsContain(other.gameObject.layer))
        {

            EnemyCotroller enmey = other.GetComponent<EnemyCotroller>();
            //tower.AddEnemey(enmey);
            enmey.ondied.AddListener( () => { OnOutRangeEnemey?.Invoke(enmey); });
            Debug.Log("몬스터들어옴");
          OnInRangeEnemey?.Invoke(enmey);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (enemyMask.IsContain(other.gameObject.layer))
        {
            EnemyCotroller enmey = other.GetComponent<EnemyCotroller>();
         //   tower.ReMoveEnemey(enmey);
            Debug.Log("몬스터나감");
            OnOutRangeEnemey?.Invoke(enmey);
        }
    }
}
