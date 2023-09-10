using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f;
    private float _damage = 1f;

    public void Awake()
    {
        _damage = PlayerPrefs.GetInt("Bullet Damage");
        Destroy(gameObject, lifeTime);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("Bullet Damage") == false)
        {
            PlayerPrefs.SetInt("Bullet Damage", 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.ReduceHealth(_damage);
            Destroy(gameObject);
        }

        BossHealth bossHealth = other.GetComponent<BossHealth>();
        if (bossHealth != null)
        {
            bossHealth.ReduceHealth(_damage);
            Destroy(gameObject);
        }
    }
}
