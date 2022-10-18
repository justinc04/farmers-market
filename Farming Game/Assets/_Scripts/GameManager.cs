using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int money;
    [SerializeField] private TextMeshProUGUI moneyText;

    private void Start()
    {
        moneyText.text = "$" + money;
    }

    private void Awake()
    {
        Instance = this;
    }

    public void Transaction(int value)
    {
        money += value;
        moneyText.text = "$" + money;
    }
}
