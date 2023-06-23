using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float totalTime = 120f; // Gesamte Zeit in Sekunden
    private float currentTime; // Aktuelle Zeit in Sekunden
    [SerializeField] TextMeshProUGUI timerText;

    private bool timerStarted = false;

    private void Start()
    {
        currentTime = totalTime;
    }

    private void Update()
    {
        // Aktualisiere den Timer und zeige ihn im Textfeld an, nur wenn der Timer gestartet wurde
        if (timerStarted)
        {
            currentTime -= Time.deltaTime;

            // Überprüfe, ob die Zeit abgelaufen ist
            if (currentTime <= 0f)
            {
                currentTime = 0f;
                // Führe hier den Code aus, der nach Ablauf des Timers ausgeführt werden soll
            }

            // Konvertiere die verbleibende Zeit in Minuten und Sekunden
            int minutes = Mathf.FloorToInt(currentTime / 60f);
            int seconds = Mathf.FloorToInt(currentTime % 60f);

            // Aktualisiere den Text des Textfelds
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void StartTimer()
    {
        // Starte den Timer
        timerStarted = true;
    }

    public void ResetTimer()
    {
        currentTime = totalTime;
        timerStarted = false; 
    }
}
