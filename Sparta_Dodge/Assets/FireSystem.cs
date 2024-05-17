using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSystem : MonoBehaviour
{
    public GameObject bulleltObj;

    [SerializeField] private float maxShotDelay = 0.2f;
    private float currentShotDelay;


    //private void Update()
    //{
    //    Fire(this.transform);
    //    Reload();
    //}
    public void Fire(Transform transform)
    {
        if (currentShotDelay < maxShotDelay)
            return;

        GameObject bullet = Instantiate(bulleltObj, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

        currentShotDelay = 0;
    }
    public void Reload()
    {
        currentShotDelay += Time.deltaTime;
    }
}
