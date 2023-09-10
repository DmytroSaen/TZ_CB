using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform roadStart;
    public Transform roadEnd;
    public int enemyCount = 5; 
    public float spawnHeight = 1.0f;
    public float minDistanceBetweenEnemies = 8f; 
    public float maxDistanceBetweenEnemies = 10f;

    private void Start()
    {
        SpawnEnemiesAlongRoad();
    }

    private void SpawnEnemiesAlongRoad()
    {
        // Рассчитываем длину дороги
        float roadLength = Vector3.Distance(roadStart.position, roadEnd.position);

        // Спавним врагов вдоль дороги
        float spawnPositionAlongRoad = 0f;
        for (int i = 0; i < enemyCount; i++)
        {
            float randomDistance = Random.Range(minDistanceBetweenEnemies, maxDistanceBetweenEnemies);

            spawnPositionAlongRoad = Mathf.Max(spawnPositionAlongRoad, i * randomDistance);

            Vector3 spawnPosition = Vector3.Lerp(roadStart.position, roadEnd.position, spawnPositionAlongRoad / roadLength);

            // Устанавливаем высоту спавна
            spawnPosition.y = spawnHeight;
            SpawnEnemyAtPosition(spawnPosition);

            spawnPositionAlongRoad += randomDistance;
        }
    }

    private void SpawnEnemyAtPosition(Vector3 spawnPosition)
    {
        // Создаем экземпляр врага из префаба
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Задаем случайную позицию по ширине (X) в диапазоне от -2 до 2 метров
        spawnPosition.x += Random.Range(-2f, 2f);

        // Задаем позицию врага
        enemy.transform.position = spawnPosition;
    }
}
