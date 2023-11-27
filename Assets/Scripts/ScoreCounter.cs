using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TMPro;
using Zenject;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmp_text;

    [Inject] private PlayerCoinCollector playerCoins;

    void Start()
    {
        playerCoins.Score.Subscribe((value) => tmp_text.text = value.ToString());
    }
}
