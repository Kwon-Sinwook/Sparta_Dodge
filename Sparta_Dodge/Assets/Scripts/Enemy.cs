using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int health;
    public Sprite[] sprites;
    private Vector2 limit = new Vector2(-12, 0);

    SpriteRenderer spriteRenderer;
   

    void Awake()
    {
        Sprite sprite = GetComponent<Sprite>();
        
    }

    private void Update()
    {
        if (transform.position.x < limit.x )
        {
            Destroy(this.gameObject);
        }
    }
}


