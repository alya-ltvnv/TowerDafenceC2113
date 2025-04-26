using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullerController : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float damage = 50;

    void Start()
    {
        Invoke("DestroyBullet", 5);
    }

    
    void FixedUpdate()
    {
        transform.position += transform.right * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().GetDamage(Random.Range(damage / 3, damage));
        }
        Destroy(gameObject);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
