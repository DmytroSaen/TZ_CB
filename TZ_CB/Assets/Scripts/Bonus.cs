using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{
    public string bonusName;
    public static event Action<string> OnTouchBonus;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            OnTouchBonus?.Invoke(bonusName);
            Destroy(gameObject);
        }
    }
}
