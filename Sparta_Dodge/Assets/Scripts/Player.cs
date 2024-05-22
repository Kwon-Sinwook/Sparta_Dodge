using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float speed;
    public int life;

    [SerializeField] private GameManager gameManager;

    public GameObject bulleltObj;

    [SerializeField] private float maxShotDelay = 0.2f;
    private float currentShotDelay;

    Animator animator;

    private bool isTouchRight;
    private bool isTouchLeft;
    private bool isTouchTop;
    private bool isTouchBottom;

    private bool isHit;
    public bool isDead = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
            h = 0;

        float v = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
            v = 0;

        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0).normalized * speed * Time.deltaTime;

        transform.position = curPos + nextPos;

        if(Input.GetButtonDown("Vertical") || Input.GetButtonUp("Vertical"))
        {
            animator.SetInteger("input", (int)v);
        }

        Fire(this.transform);
        Reload();
    }

    public void Fire(Transform transform)
    {
        if (!Input.GetButton("Jump"))
            return;

        if (currentShotDelay < maxShotDelay)
            return;

        GameObject bullet = Instantiate(bulleltObj, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.right * 10, ForceMode2D.Impulse);

        currentShotDelay = 0;
    }
    public void Reload()
    {
        currentShotDelay += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            if (isHit)
                return;

            isHit = true;

            life--;

            if(life == 0)
            {
                isDead = true;
                gameObject.SetActive(false);
                gameManager.GameOver();
            }

            Destroy(collision.gameObject);

            isHit = false;
        }
    }
}
