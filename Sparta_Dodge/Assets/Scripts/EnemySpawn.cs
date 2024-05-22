using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float speed = 3f;
    private int health;
    public Sprite[] sprites;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;

    public GameObject bulleltObj;
    public GameObject player;
    public ObjectManager objectManager;

    [SerializeField] private float maxShotDelay = 1f;
    private float currentShotDelay;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
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

        GameObject bullet = objectManager.MakeObj("BulletEnemy");
        bullet.transform.position = transform.position;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        Vector2 direction = (player.transform.position - transform.position).normalized;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, rotZ-90f);

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

        CheckDestroy();
    }

    void OnHitEffect()
    {
        spriteRenderer.sprite = sprites[0];
    }

    void CheckDestroy()
    {
        if (health <= 0)
        {
            animator.SetTrigger("Die");
            GameObject.Find("ScoreBoardManager").GetComponent<ScoreBoardManager>().UpdateScore(10f);
            gameObject.SetActive(false);
           
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            gameObject.SetActive(false);
          
        }
        else if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit();
        }
    }

}
