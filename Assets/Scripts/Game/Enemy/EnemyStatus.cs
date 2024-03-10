using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public float maxHp;

    float hp;
    float mp;

    public float MaxHp => maxHp;
    public float Hp => Mathf.Clamp(hp, 0, MaxHp);
    public bool isDead => hp <= 0;
    void Start()
    {
        hp = MaxHp;
    }

    public void MinusHp(float damage)
    {
        hp -= damage;
    }

}
