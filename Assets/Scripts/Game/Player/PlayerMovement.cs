using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerMovement : Singleton<PlayerMovement>
{
    public float moveSpeed;
    [SerializeField] Arrow arrowPrefab;

    [SerializeField] TalkManager1 talkManager;
    [SerializeField] TalkBundel1[] DeathTalkBundle;

    [Header("Exp")]
    [SerializeField] int[] needExps;

    [Header("Effect")]
    [SerializeField] GameObject effect1;
    [SerializeField] GameObject effect2;
    [SerializeField] GameObject effect3;
    [SerializeField] GameObject effect4;
    [SerializeField] GameObject effect5;
    [SerializeField] GameObject effect6;
    [SerializeField] GameObject effect7;
    [SerializeField] GameObject effect8;
    [SerializeField] GameObject effect9;

    SpriteRenderer sprite;
    Animator anim;

    LayerMask EnemyMask;
    LayerMask SkeletonMask;
    LayerMask BringerMask;
    LayerMask CatMask;

    Rigidbody2D rigid;
    Vector3 dir;

    public float attackPower;
    public float arrowPower;

    public int level;
    int exp;
    private int NeedExp => needExps[level - 1];
    private int MaxLevel => needExps.Length - 1;

    public float waitTime;
    float currentTime;

    public float swordAttackRadius;
    public float bowAttackRadius;
    public float knockbackRange;
    public float sturnTime;

    float hideTime = 0.0f;

    void Start()
    {
        waitTime = 1.5f;
        currentTime = 0;
        moveSpeed = 5.0f;
        swordAttackRadius = 1.0f;
        bowAttackRadius = 5.0f;
        knockbackRange = 0.4f;
        attackPower = 10;
        arrowPower = 7;
        sturnTime = 0.5f;

        level = 1;
        exp = 0;
        ExpBarUI.Instance.UpdateExp(exp, NeedExp);
        ExpBarUI.Instance.UpdateLevel(level);

        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        EnemyMask = 1 << LayerMask.NameToLayer("Enemy");
        SkeletonMask = 1 << LayerMask.NameToLayer("Skeleton");
        BringerMask = 1 << LayerMask.NameToLayer("Bringer");
        CatMask = 1 << LayerMask.NameToLayer("Cat");

        transform.position = new Vector3(-37.86f, -0.51f, 0f);

        effect1.SetActive(false);
        effect2.SetActive(false);
        effect3.SetActive(false);
        effect4.SetActive(false);
        effect5.SetActive(false);
        effect6.SetActive(false);
        effect7.SetActive(false);
        effect8.SetActive(false);
        effect9.SetActive(false);
    }

    void Update()
    {
        Movement();

        currentTime += Time.deltaTime;
        
        if (currentTime > waitTime) 
        {
            Attack();
        }

        if(Input.GetKeyDown(KeyCode.Q) && GameManager.Instance.ActiveSkillQ == true && StatusManager.Instance.mp >= 20)
        {
            SkillQ();
        }
        else if(Input.GetKeyDown(KeyCode.W) && GameManager.Instance.ActiveSkillW == true && StatusManager.Instance.mp >= 20) 
        {
            SkillW();
        }
        else if(Input.GetKeyDown(KeyCode.E) && GameManager.Instance.ActiveSkillE == true && StatusManager.Instance.mp >= 20) 
        {
            SkillE();
        }
        else if (Input.GetKeyDown(KeyCode.R) && GameManager.Instance.ActiveSkillR == true && StatusManager.Instance.mp >= 20)
        {
            SkillR();
        }

        if(SkillManager.Instance.PassiveSkill_13 >= 1)
        {
            effect1.SetActive(true);
        }

        if (SkillManager.Instance.PassiveSkill_14 >= 1)
        {
            effect2.SetActive(true);
        }

        if (SkillManager.Instance.PassiveSkill_15 >= 1)
        {
            effect3.SetActive(true);
        }

        if (SkillManager.Instance.PassiveSkill_16 >= 1)
        {
            effect4.SetActive(true);
        }

        if (SkillManager.Instance.PassiveSkill_17 >= 1)
        {
            effect5.SetActive(true);
        }

        if (SkillManager.Instance.PassiveSkill_18 >= 1)
        {
            effect6.SetActive(true);
        }

        if (SkillManager.Instance.PassiveSkill_19 >= 1)
        {
            effect7.SetActive(true);
        }

        if (SkillManager.Instance.PassiveSkill_20 >= 1)
        {
            effect8.SetActive(true);
        }

        if (SkillManager.Instance.PassiveSkill_21 >= 1)
        {
            effect9.SetActive(true);
        }

        Death();
    }

    public void Movement()
    {
        rigid.velocity = new Vector2(0, 0);

        if(GameManager.Instance.isPause == true)
        {
            anim.speed = 0.0f;
            return;
        }

        if(StatusManager.Instance.isDead == true)
        {
            return;
        }

        anim.speed = 1.0f;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x == 0 && y == -1)
            return;

        dir = new Vector3(x, y).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;

        anim.SetFloat("x", x);
        anim.SetFloat("y", y);
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.A) && GameManager.Instance.StateNum == 1)
        {
            anim.SetTrigger("onSlash");

           if(SkillManager.Instance.PassiveSkill_14 >= 1)
            {
                PassiveSkill14();

                Collider2D skeleton = Physics2D.OverlapCircle(transform.position, swordAttackRadius, SkeletonMask);
                if (skeleton != null)
                {
                    skeleton.GetComponent<Skeleton>().TakeDamage(attackPower);
                }

                Collider2D bringer = Physics2D.OverlapCircle(transform.position, swordAttackRadius, BringerMask);
                if (bringer != null)
                {
                    bringer.GetComponent<Bringer>().TakeDamage(attackPower);
                }

                Collider2D cat = Physics2D.OverlapCircle(transform.position, swordAttackRadius, CatMask);
                if (cat != null)
                {
                    cat.GetComponent<Cat>().TakeDamage(attackPower);
                }
            }
           else
            {
                Collider2D enemy = Physics2D.OverlapCircle(transform.position, swordAttackRadius, EnemyMask);
                if (enemy != null)
                {
                    enemy.GetComponent<Enemy>().TakeDamage(attackPower);
                }

                Collider2D skeleton = Physics2D.OverlapCircle(transform.position, swordAttackRadius, SkeletonMask);
                if (skeleton != null)
                {
                    skeleton.GetComponent<Skeleton>().TakeDamage(attackPower);
                }

                Collider2D bringer = Physics2D.OverlapCircle(transform.position, swordAttackRadius, BringerMask);
                if (bringer != null)
                {
                    bringer.GetComponent<Bringer>().TakeDamage(attackPower);
                }

                Collider2D cat = Physics2D.OverlapCircle(transform.position, swordAttackRadius, CatMask);
                if (cat != null)
                {
                    cat.GetComponent<Cat>().TakeDamage(attackPower);
                }
            }

           if(SkillManager.Instance.PassiveSkill_13 >= 1)
            {
                Collider2D enemy = Physics2D.OverlapCircle(transform.position, 3, EnemyMask);

                if (enemy != null)
                {
                    if (GameManager.Instance.StateNum == 1)
                        enemy.GetComponent<Enemy>().TakeDamage(attackPower);
                }
            }

            if (SkillManager.Instance.PassiveSkill_15 >= 1)
            {
                Skill15();
            }

            if (SkillManager.Instance.PassiveSkill_16 >= 1)
            {
                Skill16();
            }

            currentTime = 0;
        }

        if (Input.GetKeyDown(KeyCode.A) && GameManager.Instance.StateNum == 2)
        {
            anim.SetTrigger("onBow");

            makeArrow();

            if(SkillManager.Instance.arrowCount >= 2)
            {
                Invoke("makeArrow", 0.18f);
            }
            if (SkillManager.Instance.arrowCount >= 3)
            {
                Invoke("makeArrow", 0.3f);
            }

            currentTime = 0;
        }

    }

    private void makeArrow()
    {
        Arrow arrow = Instantiate(arrowPrefab);
        arrow.transform.position = transform.position;
        arrow.transform.rotation = Quaternion.FromToRotation(arrow.transform.up, dir);
    }

    public void SkillQ()
    {
        moveSpeed = moveSpeed * 2;
        StatusManager.Instance.MinusMp(20);

        GameManager.Instance.ActiveSkillQ = false;
    }

    public void SkillW()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        dir = new Vector3(x, y).normalized;
        transform.position += dir * 2.0f;
        StatusManager.Instance.MinusMp(20);

        GameManager.Instance.ActiveSkillW = false;
    }

    public void SkillE()
    {
        StatusManager.Instance.MinusMp(20);

        Collider2D[] enemys = Physics2D.OverlapCircleAll(transform.position, swordAttackRadius, EnemyMask);

        if(enemys != null)
        {
            for (int i = 0; i <= enemys.Length - 1; i++)
            {
                if(GameManager.Instance.StateNum == 1)
                    enemys[i].GetComponent<Enemy>().GetSkillE(attackPower);

                if(GameManager.Instance.StateNum == 2)
                    enemys[i].GetComponent<Enemy>().GetSkillE(arrowPower * SkillManager.Instance.arrowCount);

            }
        }

        GameManager.Instance.ActiveSkillE = false;
    }

    public void Skill15()
    {
        Collider2D enemy = Physics2D.OverlapCircle(transform.position, swordAttackRadius, EnemyMask);

        if (enemy != null)
        {
            if (GameManager.Instance.StateNum == 1)
                enemy.GetComponent<Enemy>().GetSkill15(attackPower);
        }
    }

    public void Skill16()
    {
        Collider2D[] enemys = Physics2D.OverlapCircleAll(transform.position, swordAttackRadius, EnemyMask);

        if (enemys != null)
        {
            for (int i = 0; i <= enemys.Length - 1; i++)
            {
                if (GameManager.Instance.StateNum == 1)
                    enemys[i].GetComponent<Enemy>().GetSkill16(attackPower);

            }
        }
    }
    public void SkillR()
    {
        StatusManager.Instance.MinusMp(20);

        StartCoroutine(IESkillR());
        
        GameManager.Instance.ActiveSkillR = false;
    }

    IEnumerator IESkillR()
    {
        gameObject.tag = "Untagged";
        gameObject.layer = 0;

        sprite.material.color = new Color(sprite.material.color.r, sprite.material.color.g, sprite.material.color.b, 0.5f);

        while (hideTime < 3.0f)
        {
            hideTime += Time.deltaTime;
            yield return null;
        }

        sprite.material.color = new Color(sprite.material.color.r, sprite.material.color.g, sprite.material.color.b, 1.0f);
        gameObject.tag = "Player";
        gameObject.layer = 3;
        hideTime = 0.0f;
    }

    public void GetExp(int amount)
    {
        if (level >= MaxLevel)
        {
            return;
        }

        exp += amount;
        if (exp >= NeedExp)
        {
            exp -= NeedExp;
            level++;
            SkillManager.Instance.SkillGacha();
            GameManager.Instance.isPause = true;

            if (level >= MaxLevel)
            {
                exp = 0;
            }
        }

        ExpBarUI.Instance.UpdateExp(exp, NeedExp);
        ExpBarUI.Instance.UpdateLevel(level);
    }

    public void PassiveSkill14()
    {
        Collider2D[] enemys = Physics2D.OverlapCircleAll(transform.position, swordAttackRadius, EnemyMask);

        if (enemys != null)
        {
            for (int i = 0; i <= enemys.Length - 1; i++)
            {
                if (GameManager.Instance.StateNum == 1)
                    enemys[i].GetComponent<Enemy>().TakeDamage(attackPower);

                if (GameManager.Instance.StateNum == 2)
                    enemys[i].GetComponent<Enemy>().TakeDamage(arrowPower);


            }
        }
    }

    void Death()
    {
        if (StatusManager.Instance.isDead == true)
        {
            DeathUI.Instance.OpenDeath();
            anim.SetTrigger("onDead");
            float animTime = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
            if (animTime >= 1.0f)
            {
                talkManager.StartTalk(DeathTalkBundle[0]);
            }
            
        }

    }
}
