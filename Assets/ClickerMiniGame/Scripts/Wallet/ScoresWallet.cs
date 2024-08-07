using System;
using UnityEngine;

public class ScoresWallet : MonoBehaviour
{
    private int _scores = 0;

    public Action<int> ScoresChanged;

    public void Init(int value)
    {
        _scores = value;
        ScoresChanged?.Invoke(_scores);
    }

    public void AddScores(int value)
    {
        if (value > 0)
        {
            _scores += value;
            ScoresChanged?.Invoke(_scores);
        }
    }

    public void DecreaseScores(int value)
    {
        if (value > 0)
        {
            _scores -= value;
            ScoresChanged?.Invoke(_scores);
        }
    }
}