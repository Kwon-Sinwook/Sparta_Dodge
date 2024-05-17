using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int health;
    public Sprite[] sprites;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rb2D;

    void Awake()
    {
        Sprite sprite = GetComponent<Sprite>();
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = Vector2.left * speed;
    }


}


