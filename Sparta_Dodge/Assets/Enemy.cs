using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private int health = 1;
    public Sprite[] sprites;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
    }

    void OnHit(int dmg = 1)
    {
        health -= dmg;
        spriteRenderer.sprite = sprites[1];
        Invoke("OnHitEffect", 0.1f);
        Invoke("CheckDestroy", 0.4f);
    }

    void OnHitEffect()
    {
        spriteRenderer.sprite = sprites[0];
    }

    void CheckDestroy()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit();
        }
    }

}
