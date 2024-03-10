using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public int EnemyPower = 1;
    public float moveSpeed;
    public int EXP;

    StatusManager playerStatus;
    EnemyStatus EnemyStatus;

    Animator anim;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;

    Transform target;
    Vector2 startPos;

    LayerMask PlayerMask;

    float strunTime = 0.0f;

    bool checkSlow;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerStatus = collision.gameObject.GetComponent<StatusManager>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerStatus = null;
        }
    }

    private void Start()
    {
        target = PlayerMovement.Instance.transform;
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        EnemyStatus = GetComponent<EnemyStatus>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        moveSpeed = 4.0f;

        StartCoroutine(IEAttack());

        startPos = transform.position;
        PlayerMask = 1 << LayerMask.NameToLayer("Player");
    }
    void Update()
    {
        if (EnemyStatus.isDead == true)
        {
            anim.SetTrigger("onDead");
        }

        if ((GameManager.Instance.onSturn == true && strunTime > PlayerMovement.Instance.sturnTime) || (GameManager.Instance.onSturn == true && strunTime == 0.0f) || GameManager.Instance.onSturn == false)
        {
            Flying();
        }
    }

    IEnumerator IEAttack()
    {
        while (true) 
        {
            if (playerStatus != null)
            {
                playerStatus.MinusHp(EnemyPower);
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    public void TakeDamage(float damage)
    {
        anim.SetTrigger("onHit");

        EnemyStatus.MinusHp(damage);
        DamageUIManager.Instance.Show(damage, transform.position);

        if(GameManager.Instance.onNockBack == true)
        {
            Vector3 dir = (transform.position - target.position).normalized;    //상대방이 나를 바라보는 방향벡터 의 정규화
            transform.Translate(dir * PlayerMovement.Instance.knockbackRange);    //상대방이 나를 바라보는 방향으로 밀리게됨
        }

        if (GameManager.Instance.onSlow == true && checkSlow == false)
        {
            OnSlow();
            checkSlow = true;
        }

        if(SkillManager.Instance.PassiveSkill_17 >= 1)
        {
            OnSlow();
        }
    }

    public void Sturn()
    {
        if (GameManager.Instance.onSturn == true)
        {
            StartCoroutine(IEStrtn());
        }
        else
        { return; }
        
    }
    IEnumerator IEStrtn()
    {
        anim.speed = 0.0f;

        while (strunTime < PlayerMovement.Instance.sturnTime) 
        {
            strunTime += Time.deltaTime;
            
            yield return null;
        }

        anim.speed = 1.0f;
        strunTime = 0.0f;
    }

    public void OnDead()
    {
        PlayerMovement.Instance.GetExp(EXP);
        GameManager.Instance.monsterCount++;
        Destroy(gameObject);
    }

    public void OnSlow()
    {
        StartCoroutine(IESlowTimer());
    }

    IEnumerator IESlowTimer()
    {
        float firstSpeed = moveSpeed;
        moveSpeed -= moveSpeed * 0.5f;
        float time = 0.0f;
        while(time < 2.0f)
        {
            time += Time.deltaTime;
            yield return null;
        }

        time = 0.0f;
        moveSpeed = firstSpeed;

    }

    public void Flying()
    {
        if (GameManager.Instance.isPause == true)
        {
            return;
        }

        if (StatusManager.Instance.isDead == true)
        {
            return;
        }

        Vector2 dir = startPos + Random.insideUnitCircle * 10;
        transform.position = Vector3.MoveTowards(transform.position, dir, moveSpeed * Time.deltaTime);

        Collider2D player = Physics2D.OverlapCircle(transform.position, 10f, PlayerMask);
        if (player != null) 
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        }

        if ((target.transform.position - transform.position).x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    public void GetSkillE(float damage)
    {
        anim.SetTrigger("onHit");

        EnemyStatus.MinusHp(damage);
        DamageUIManager.Instance.Show(damage, transform.position);

        Vector3 dir = (transform.position - target.position).normalized;    //상대방이 나를 바라보는 방향벡터 의 정규화
        transform.Translate(dir * 4.5f);    //상대방이 나를 바라보는 방향으로 밀리게됨
    }

    public void GetSkill15(float damage)
    {
        anim.SetTrigger("onHit");

        EnemyStatus.MinusHp(damage);
        DamageUIManager.Instance.Show(damage, transform.position);

        Vector3 dir = (transform.position - target.position).normalized;    //상대방이 나를 바라보는 방향벡터 의 정규화
        transform.Translate(dir * 3.5f);    //상대방이 나를 바라보는 방향으로 밀리게됨
    }

    public void GetSkill16(float damage)
    {
        anim.SetTrigger("onHit");

        EnemyStatus.MinusHp(damage);
        DamageUIManager.Instance.Show(damage, transform.position);

        Vector3 dir = (transform.position - target.position).normalized;    //상대방이 나를 바라보는 방향벡터 의 정규화
        transform.Translate(dir * 2.5f);    //상대방이 나를 바라보는 방향으로 밀리게됨
    }
}
