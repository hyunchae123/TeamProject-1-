using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] int moveSpeed;

    SpriteRenderer sprite;

    Enemy enemy;
    Skeleton skeleton;
    Bringer bringer;
    Cat cat;

    Vector3 dir;
    Vector3 destination;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<Enemy>();
        }
        else if(collision.tag == "Skeleton")
        {
            skeleton = collision.gameObject.GetComponent<Skeleton>();
        }
        else if( collision.tag == "Bringer")
        {
            bringer = collision.gameObject.GetComponent<Bringer>();
        }
        else if (collision.tag == "Cat")
        {
            cat = collision.gameObject.GetComponent<Cat>();
        }
    }

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        dir = new Vector3(x, y, 0).normalized;
        destination = transform.position + dir * PlayerMovement.Instance.bowAttackRadius;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

        if (enemy != null) 
        {
            if (SkillManager.Instance.PassiveSkill_21 >= 1)
            {
                int ran = Random.Range(1, 10);
                if (ran <= 2)
                {
                    enemy.GetComponent<Enemy>().TakeDamage(9999);
                }
                else
                {
                    enemy.TakeDamage(PlayerMovement.Instance.arrowPower);
                }
            }
            else
            {
                enemy.TakeDamage(PlayerMovement.Instance.arrowPower);
            }
            
            Destroy(gameObject);
        }

        if (skeleton != null)
        {
            if(SkillManager.Instance.PassiveSkill_21 >= 1)
            {
                int ran = Random.Range(1, 10);
                if (ran <= 2)
                {
                    skeleton.GetComponent<Skeleton>().TakeDamage(9999);
                }
                else
                {
                    skeleton.TakeDamage(PlayerMovement.Instance.arrowPower);
                }
            }
            else
            {
                skeleton.TakeDamage(PlayerMovement.Instance.arrowPower);
            }
            
            Destroy(gameObject);
        }

        if (bringer != null)
        {
            if (SkillManager.Instance.PassiveSkill_21 >= 1)
            {
                int ran = Random.Range(1, 10);
                if (ran <= 2)
                {
                    bringer.GetComponent<Bringer>().TakeDamage(9999);
                }
                else
                {
                    bringer.TakeDamage(PlayerMovement.Instance.arrowPower);
                }
            }
            else
            {
                bringer.TakeDamage(PlayerMovement.Instance.arrowPower);
            }
            
            Destroy(gameObject);
        }

        if (cat != null)
        {
            if (SkillManager.Instance.PassiveSkill_21 >= 1)
            {
                int ran = Random.Range(1, 10);
                if (ran <= 2)
                {
                    cat.GetComponent<Cat>().TakeDamage(9999);
                }
                else
                {
                    cat.TakeDamage(PlayerMovement.Instance.arrowPower);
                }
            }
            else
            {
                cat.TakeDamage(PlayerMovement.Instance.arrowPower);
            }
                
            Destroy(gameObject);
        }

        if (transform.position == destination)
        {
            Destroy(gameObject);
        }

        if(SkillManager.Instance.PassiveSkill_9 >= 1)
        {
            sprite.material.color = new Color(255, 0, 0, 1.0f);
        }

    }

}
