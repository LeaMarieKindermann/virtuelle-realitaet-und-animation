using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void AddScore(int points)
    {
        score += points;

        // Hier kannst du weitere Aktionen basierend auf dem erreichten Punktestand ausführen
        Debug.Log("Punktezahl" + score);
    }
}

