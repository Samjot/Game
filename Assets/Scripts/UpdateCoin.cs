using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCoin : MonoBehaviour {

    public Text CoinText;
    int Coin = 0;

    public void UpdateCoin1()
    {
        Coin++;
        CoinText.text = "Coin:" + Coin;
    }

    public void UpdateCoin1(int newCoin)
    {
        Coin = newCoin;
        CoinText.text = "Coin:" + Coin;
    }
}
