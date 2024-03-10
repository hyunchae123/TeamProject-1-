using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatusManager : Singleton<StatusManager>
{
    public float maxHp;
    public float maxMp;

    public float HPfillAmount;
    public float MPfillAmount;

    public float hp;
    public float mp;

    public float MaxHp => maxHp;
    public float MaxMp => maxMp;
    public float Hp => Mathf.FloorToInt(Mathf.Clamp(hp, 0, MaxHp));
    public float Mp => Mathf.FloorToInt(Mathf.Clamp(mp, 0, MaxMp));
    public bool isDead => hp <= 0;
    void Start()
    {
        hp = MaxHp;
        mp = MaxMp;

        HPfillAmount = 1;
        MPfillAmount = 1;

        StartCoroutine(IEPlusHP());

        StartCoroutine(IEPlusMP());
    }

    IEnumerator IEPlusHP()
    {
        while (true)
        {
            if(hp < MaxHp)
            {
                hp = Mathf.Clamp(hp + HPfillAmount, 0, MaxHp);
            }
            
            yield return new WaitForSeconds(1.0f);
        }

    }

    IEnumerator IEPlusMP()
    {
        while (true)
        {
            if (mp < MaxHp)
            {
                mp = Mathf.Clamp(mp + MPfillAmount, 0, MaxMp);
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    public void MinusHp(float damage)
    {
        hp -= damage;
    }

    public void MinusMp(float damage)
    {
        mp -= damage;
    }
}
