using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private BossController _boss;
    private void Start()
    {
        _boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
    }

    public void FinishRoad()
    {
        _boss.UpdateSpeedBoss();
    }
}
