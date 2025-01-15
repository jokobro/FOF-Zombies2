using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private TMP_Text pointsUiText;
    public float Points;
    public float scoreMultiplier = 1f;

    private void Awake()
    {
        Instance = this;
    }
 
    private void Start()
    {
        UpdatePointsUI();
    }

    public void AddScore(int pointsAmount)
    {
        Points += Mathf.RoundToInt(pointsAmount * scoreMultiplier);
        pointsUiText.SetText($"{Points}");
    }

    public void UpdatePointsUI()
    {
        pointsUiText.SetText($"{Points}");
    }
}
