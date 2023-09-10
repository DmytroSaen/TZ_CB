using System;
using UnityEngine;
using TMPro;

public class EventManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsTxt;

    private void Awake()
    {
        _coinsTxt.text = PlayerPrefs.GetInt("coins").ToString();
    }
    void Start()
    {
        Bonus.OnTouchBonus += BonusTouchHandler; // подписываемся на событие
    }
    private void BonusTouchHandler(string bonusName)
    {
        switch (bonusName)
        {
            case "coin":
                int coins = PlayerPrefs.GetInt("coins");
                PlayerPrefs.SetInt("coins", coins + 1);
                _coinsTxt.text = (coins + 1).ToString();
                break;
        }
    }
    private void OnDestroy()
    {
        Bonus.OnTouchBonus -= BonusTouchHandler; // отписываемся от события

    }
}