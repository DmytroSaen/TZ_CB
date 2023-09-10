using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] Animator animator;
    private float _moveSpeed = 0f;

    void Update()
    {
        animator.SetFloat("SpeedZ", _moveSpeed);
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }

    public void UpdateSpeedBoss()
    {
        _moveSpeed = -0.5f;
    }
}
