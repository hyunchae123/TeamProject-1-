using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bringer : MonoBehaviour
{
    public int EnemyPower = 5;
    public float moveSpeed;
    public int EXP;

    StatusManager playerStatus;
    EnemyStatus EnemyStatus;
    Animator anim;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    Transform target;
    LayerMask PlayerMask;

    float strunTime = 0.0f;

    bool checkSlow;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerStatus = collision.gameObject.GetComponent<StatusManager>();
            anim.SetBool("onAttack", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerStatus = null;
            anim.SetBool("onAttack", false);
        }
    }

    private void Start()
    {
        target = PlayerMovement.Instance.transform;
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        EnemyStatus = GetComponent<EnemyStatus>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(IEAttack());

        PlayerMask = 1 << LayerMask.NameToLayer("Player");
    }
    void Update()
    {
        if (EnemyStatus.isDead == true)
        {
            anim.SetTrigger("onDead");
        }

        if ((GameManager.Instance.onSturn == true && strunTime > 0.5f) || (GameManager.Instance.onSturn == true && strunTime == 0.0f) || GameManager.Instance.onSturn == false)
        {
            Movement();
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
        EnemyStatus.MinusHp(damage);
        DamageUIManager.Instance.Show(damage, transform.position);
        if (GameManager.Instance.onNockBack == true)
        {
            Vector3 dir = (transform.position - target.position).normalized;    //상대방이 나를 바라보는 방향벡터 의 정규화
            transform.Translate(dir * PlayerMovement.Instance.knockbackRange);    //상대방이 나를 바라보는 방향으로 밀리게됨
        }

        anim.SetTrigger("onHit");

        if (GameManager.Instance.onSlow == true && checkSlow == false)
        {
            OnSlow();
            checkSlow = true;
        }

        if (SkillManager.Instance.PassiveSkill_17 >= 1)
        {
            OnSlow();
        }
    }

    public void OnSlow()
    {
        moveSpeed -= moveSpeed * 0.5f;
    }

    public void OnDead()
    {
        PlayerMovement.Instance.GetExp(EXP);
        GameManager.Instance.monsterCount++;
        Destroy(gameObject);
    }

    public void Movement()
    {
        if (GameManager.Instance.isPause == true)
        {
            return;
        }

        if (StatusManager.Instance.isDead == true)
        {
            return;
        }

        Collider2D player = Physics2D.OverlapCircle(transform.position, 10f, PlayerMask);
        if (player != null)
        {
            anim.SetBool("isWalk", true);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }

        if ((target.transform.position - transform.position).x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
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

        while (strunTime < 0.5f)
        {
            strunTime += Time.deltaTime;

            yield return null;
        }

        anim.speed = 1.0f;
        strunTime = 0.0f;
    }
}
