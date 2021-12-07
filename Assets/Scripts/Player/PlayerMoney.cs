using System;
using TMPro;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;

    private int _money;
    public int Money => _money;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Money"))
            _money = PlayerPrefs.GetInt("Money");
        ChangeMoney(0);
    }

    public void ChangeMoney(int difference)
    {
        _money += difference;
        PlayerPrefs.SetInt("Money", _money);
        _moneyText.text = $"{_money}";
    }
}
