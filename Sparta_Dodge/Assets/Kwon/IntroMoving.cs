using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMoving : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer renderer;
    // Start is called before the first frame update

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        rigid.velocity = Vector2.right * 2;
    }

    void Update()
    {
        if (transform.position.x > 20)
        {
            renderer.flipY = true;
            rigid.velocity = Vector2.left * 2;
        }

        else if (transform.position.x < -20)
        {
            renderer.flipY = false;
            rigid.velocity = Vector2.right * 2;
        }
    }
}
