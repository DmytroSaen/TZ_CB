using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private GameObject WinCanvas;

    private int minHealth = 50;
    private int maxHealth = 90;
    private float health;

    public TextMeshPro healthCount;

    private void Awake()
    {
        health = Random.Range(minHealth, maxHealth + 1); //+1 to include the upper limit in the range

        healthCount.text = health.ToString();
    }

    public void ReduceHealth(float damage)
    {
        health -= damage;
        healthCount.text = health.ToString();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        WinCanvas.SetActive(true);
    }
}
