using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private Color highHealthColor;
    [SerializeField] private Color lowHealthColor;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        float val = player.Health / player.MaxHealth;
        _image.fillAmount = val;
        _image.color = Color.Lerp(lowHealthColor, highHealthColor, val);
        _image.SetAllDirty();
    }
}