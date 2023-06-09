using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackRange : MonoBehaviour
{
    public Tower tower;
    public LayerMask enemyMask;
    //ó���� �����°� �÷����� �Ҷ� �ִܰŸ� �񱳷� �ҷ����ߴµ� �׷��� ���귮�� �ʹ� ���Ƽ� Ʈ���� �浹ü ���°� ���ϴ�

   public UnityEvent<EnemyCotroller> OnInRangeEnemey;
   public UnityEvent<EnemyCotroller> OnOutRangeEnemey;

    private void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.layer == enemyMask)  �̰� ������ �ȸ��� ���̾�� ���Ӹ���Ʈ ���ڰ� �ٸ��� why? ���̾��ũ�� ��Ʈ���������ؼ� 
        //���̾� 1�����Ҷ����� 2���������� �����Ѵ�.
        if (enemyMask.IsContain(other.gameObject.layer))
        {

            EnemyCotroller enmey = other.GetComponent<EnemyCotroller>();
            //tower.AddEnemey(enmey);
            enmey.ondied.AddListener( () => { OnOutRangeEnemey?.Invoke(enmey); });
            Debug.Log("���͵���");
          OnInRangeEnemey?.Invoke(enmey);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (enemyMask.IsContain(other.gameObject.layer))
        {
            EnemyCotroller enmey = other.GetComponent<EnemyCotroller>();
         //   tower.ReMoveEnemey(enmey);
            Debug.Log("���ͳ���");
            OnOutRangeEnemey?.Invoke(enmey);
        }
    }
}
