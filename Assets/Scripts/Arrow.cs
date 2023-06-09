using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float Arrowspeed;
    private EnemyCotroller enemy;
    private int Damage;
    Vector3 targetpoint;

    public void SetTarGet(EnemyCotroller enemy)
    {
        this.enemy = enemy;
        targetpoint = enemy.transform.position;
        StartCoroutine(ArrowRoutin());
    }
    public void SetDamage(int Damage)
    {
        this.Damage = Damage;
    }

 

    IEnumerator ArrowRoutin()
    {
        while (true)
        {
            
            if(enemy!= null)
           
            targetpoint = enemy.transform.position;

            transform.LookAt(targetpoint);
            transform.Translate(Vector3.forward* Arrowspeed*Time.deltaTime,Space.Self);

            if(Vector3.Distance(targetpoint, transform.position) < 0.1f)
            {
                if(enemy != null)
                Attack(enemy);
                GameManager.Resource.Destroy(gameObject);
                yield break;
            }

            yield return null;
        }
    }

    public void Attack(EnemyCotroller enemy)
    {

        enemy.TakeHit(Damage);
    }
}
