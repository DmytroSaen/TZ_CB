using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsTxt;

    public Image[] emptyIcon;
    public Sprite fillIcon;

    public string product;
    public int upgradeLimit;

    private int countIcons = 0;
    private int _countMoney;

    private void Start()
    {
        IconsUpdate();
    }

    public void ProductUpgrade()
    {
        int count = PlayerPrefs.GetInt(product);
        _countMoney = PlayerPrefs.GetInt("coins");

        if (_countMoney > 0)
        {
            if (count < upgradeLimit)
            {
                count++;
                PlayerPrefs.SetInt(product, count);

                emptyIcon[count - 1].overrideSprite = fillIcon;
                WasteOfMoney();
            }
        }
    }

    public void ProductUpgradeBulletSpeed()
    {
        float count = PlayerPrefs.GetFloat(product);
        _countMoney = PlayerPrefs.GetInt("coins");

        if (_countMoney > 0)
        {
            if (countIcons < upgradeLimit)
            {
                countIcons += 1;
                count -= 0.05f;
                PlayerPrefs.SetFloat(product, count);

                emptyIcon[countIcons - 1].overrideSprite = fillIcon;
                WasteOfMoney();
            }
        }
    }

    private void IconsUpdate()
    {
        int count = PlayerPrefs.GetInt(product);

        for (int i = 0; i < count; i++)
        {
            emptyIcon[i].overrideSprite = fillIcon;
        }
        for (int i = 0; i < countIcons; i++)
        {
            emptyIcon[i].overrideSprite = fillIcon;
        }
    }

    private void WasteOfMoney()
    {
        _countMoney = PlayerPrefs.GetInt("coins");
        PlayerPrefs.SetInt("coins", _countMoney - 1);
        _coinsTxt.text = (_countMoney - 1).ToString();
    }
}
