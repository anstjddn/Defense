using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] float Range;
    private EnemyCotroller enemy;
    private int Damage;
    Vector3 targetpoint;

    public void SetTarGet(EnemyCotroller enemy)
    {
        
        targetpoint = enemy.transform.position;
        StartCoroutine(CanonRoutin());
    }
    public void SetDamage(int Damage)
    {
        this.Damage = Damage;
    }



    IEnumerator CanonRoutin()
    {
        float Xspeed = (targetpoint.x - transform.position.x) / time;
        float zspeed = (targetpoint.z - transform.position.z) / time;
        float yspeed = -1 * (0.5f * Physics.gravity.y * time * time+transform.position.y) / time; 
        float curTime = 0;
        while (curTime< time)
        {
            curTime += Time.deltaTime;

            transform.position += new Vector3(Xspeed, yspeed, zspeed) * Time.deltaTime;

            yspeed += Physics.gravity.y * Time.deltaTime;
            yield return null;
        }
        Explostion();
        GameManager.Resource.Destroy(gameObject);
    }
    public void Explostion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, Range,LayerMask.GetMask("Enemy"));
        foreach(Collider collider in colliders)
        {
            EnemyCotroller enemy = collider.GetComponent<EnemyCotroller>();
            enemy?.TakeHit(Damage);

       
        }
    }

  /*  public void Attack(EnemyCotroller enemy)
    {
        // 오버랩은 안에 잇는 애들 검출방법 충돌체의 진입이나 나가는건 잘 파악하는데 충돌체 안에서의 상호작용은 잘인식 X
        Collider[] colliders = Physics.OverlapSphere(transform.position, Range);
            //오버랩 반환형은 충돌체 배열로 반환한다.
        enemy.TakeHit(Damage);
    }*/

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
