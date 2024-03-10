using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rigid;

    StatusManager playerStatus;
    EnemyStatus EnemyStatus;

    Transform target;

    LayerMask PlayerMask;

    public int EnemyPower = 5;
    public float moveSpeed;
    public int EXP;

    float strunTime = 0.0f;

    bool checkSlow;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerStatus = collision.gameObject.GetComponent<StatusManager>();
            rigid.velocity = new Vector2(0, 0);
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

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        EnemyStatus = GetComponent<EnemyStatus>();

        target = PlayerMovement.Instance.transform;

        PlayerMask = 1 << LayerMask.NameToLayer("Player");

        StartCoroutine(IEAttack());
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
        else
        {
            rigid.velocity = new Vector2(0, 0);
        }
        
    }

    private void Movement()
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
            Vector2 dir = target.position - transform.position;
            dir.Normalize();
            anim.SetFloat("velocityX", dir.x);
            anim.SetFloat("velocityY", dir.y);
            rigid.velocity = new Vector2(dir.x * moveSpeed, dir.y * moveSpeed);
        }
        else
        {
            Vector2 dir = new Vector2(0, 0);
            anim.SetFloat("velocityX", dir.x);
            anim.SetFloat("velocityY", dir.y);
            rigid.velocity = new Vector2(dir.x * moveSpeed, dir.y * moveSpeed);
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

            yield return new WaitForSeconds(1.0f);
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

    public void OnDead()
    {
        PlayerMovement.Instance.GetExp(EXP);
        GameManager.Instance.monsterCount++;
        Destroy(gameObject);
    }
}
