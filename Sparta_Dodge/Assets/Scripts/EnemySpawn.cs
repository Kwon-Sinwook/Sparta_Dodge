using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float speed = 3f;
    private int health = 1;
    public Sprite[] sprites;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;

    public GameObject bulleltObj;
    public GameObject player;

    [SerializeField] private float maxShotDelay = 1f;
    private float currentShotDelay;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
    }

    private void Update()
    {
        Fire(this.transform);
        Reload();
    }
    public void Fire(Transform transform)
    {
        if (currentShotDelay < maxShotDelay)
            return;

        GameObject bullet = Instantiate(bulleltObj, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        Vector3 direction = (player.transform.position - transform.position).normalized;

        rb.AddForce(direction * 5, ForceMode2D.Impulse);

        currentShotDelay = 0;
    }

    public void Reload()
    {
        currentShotDelay += Time.deltaTime;
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
            GameObject.Find("ScoreBoardManager").GetComponent<ScoreBoardManager>().UpdateScore(10f);
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
