using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerCoinCollector : MonoBehaviour
{
    public ReactiveProperty<int> Score { get; private set; }

    private int previousCoinScore;

    void Awake()
    {
        Score = new ReactiveProperty<int>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            var coin = other.GetComponent<Coin>();
            switch(coin.Type)
            {
                case CoinType.Type1:
                    Score.Value += 2;
                    previousCoinScore = 2;
                    break;
                case CoinType.Type2:
                    Score.Value += 3;
                    previousCoinScore = 3;
                    break;
                case CoinType.Type3:
                    Score.Value += previousCoinScore;
                    break;
            }

            coin.Collect();
        }
    }
}
