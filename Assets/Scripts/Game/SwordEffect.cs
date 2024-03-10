using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEffect : MonoBehaviour
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
        if (collision.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<Enemy>();
        }
        else if (collision.tag == "Skeleton")
        {
            skeleton = collision.gameObject.GetComponent<Skeleton>();
        }
        else if (collision.tag == "Bringer")
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
        destination = transform.position + dir * 3;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

        if (enemy != null)
        {
            enemy.TakeDamage(PlayerMovement.Instance.attackPower);
            Destroy(gameObject);
        }

        if (skeleton != null)
        {
            skeleton.TakeDamage(PlayerMovement.Instance.attackPower);
            Destroy(gameObject);
        }

        if (bringer != null)
        {
            bringer.TakeDamage(PlayerMovement.Instance.attackPower);
            Destroy(gameObject);
        }

        if (cat != null)
        {
            cat.TakeDamage(PlayerMovement.Instance.attackPower);
            Destroy(gameObject);
        }

        if (transform.position == destination)
        {
            Destroy(gameObject);
        }


    }
}
