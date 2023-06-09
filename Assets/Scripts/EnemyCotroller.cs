using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCotroller : MonoBehaviour
{
    [SerializeField] private int hp;

    public int HP { get { return hp; } }

    public UnityEvent<int> OnChangedHp;

    public UnityEvent ondied;
    public void TakeHit(int damage)
    {
        hp -= damage;
        OnChangedHp?.Invoke(hp);

        if (hp <= 0)
        {

            ondied?.Invoke();
            GameManager.Resource.Destroy(gameObject);
        }
        
    }
}
