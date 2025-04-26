using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TowerController : MonoBehaviour
{
    [Header("Tower Settings")]
    [SerializeField] private float range = 3f; // Дистанция атаки
    [SerializeField] private float fireRate = 1f; // Скорость стрельбы (выстрелов в секунду)
    [SerializeField] private int damage = 1; // Урон за выстрел
    [SerializeField] private float turnSpeed = 10f; // Скорость поворота башни

    [SerializeField] private GameObject projectilePrefab; // Префаб снаряда
    private Transform firePoint; // Точка вылета снаряда
    [SerializeField] private float fireCountDown = 1f; // Таймер между выстрелами

    [Header("Targeting")]
    public Transform target; // Текущая цель

    void Start()
    {
        firePoint = transform.GetChild(0).transform;
        InvokeRepeating("UpdateTarget", 0, 0.5f);
    }

    void Update()
    {
        if (target == null)
            return;

        // Поворот башни в сторону цели
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);

        // Стрельба по таймеру
        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range);
        float shortestDistance = Mathf.Infinity;

        foreach (Collider2D enemy in enemies)
        {
            if (enemy.TryGetComponent<EnemyController>(out EnemyController enemyController))
            {
                target = enemy.transform;
                break;
            }
            else
            {
                target = null;
            }
        }
    }

    // Создание снаряда
    void Shoot()
    {
        GameObject projectileGO = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}
