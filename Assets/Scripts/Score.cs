using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;

    [SerializeField] private int scoreLength = 10;
    [SerializeField] private int hitAsteroidScore = 10;
    [SerializeField] private int hitBarrierScore = 5;

    private int _score;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        UpdateUI();
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void HitAsteroid()
    {
        _score += hitAsteroidScore;
        UpdateUI();
    }

    public void HitBarrier()
    {
        _score += hitBarrierScore;
        UpdateUI();
    }

    public void ResetScore()
    {
        _score = 0;
        UpdateUI();
    }

    private void UpdateUI()
    {
        string scoreStr = _score.ToString();

        while (scoreStr.Length < scoreLength)
        {
            scoreStr = scoreStr.Insert(0, "0");
        }

        _text.text = scoreStr;
    }
}