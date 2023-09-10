using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;

    private float _speedShoot = 1f;

    private bool _canShoot = true;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Rate of fire") == false)
        {
            PlayerPrefs.SetFloat("Rate of fire", 1f);
        }
    }

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    public void StatsUpgrade()
    {
        _speedShoot = PlayerPrefs.GetFloat("Rate of fire");
    }

    private IEnumerator Shooting()
    {
        while (_canShoot)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            yield return new WaitForSeconds(_speedShoot);
            
        }
    }
}
