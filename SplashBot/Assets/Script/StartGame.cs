using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public SpawnBots startGame;
    public TimerScript timer;
    public ScoreManager scoreManager;
    public Collider gameCollider;
    public float disableDuration = 125f; // 2 Minuten in Sekunden

    private void OnCollisionEnter(Collision collision)
    {
        // Überprüfe, ob der Collider mit dem gewünschten Tag getroffen wurde
        if (collision.collider.CompareTag("bullet"))
        {
            Debug.Log("RUFT AUF");

            // Überprüfe, ob startGame und timer nicht null sind, bevor die Methoden aufgerufen werden
            if (startGame != null && timer != null)
            {
                // Score zurück setzen
                scoreManager.ResetScore();
                timer.ResetTimer();
                Debug.Log("AKTUELLER SCORE: " + scoreManager.score);
                // Timer restet

                
                startGame.StartSpawning();
                Invoke("StartTimerDelayed", 5f);

                // Collider für die definierte Zeit deaktivieren
                StartCoroutine(DisableColliderForDuration());
            }
        }
    }

    private void StartTimerDelayed()
    {
        timer.StartTimer();
    }

    private IEnumerator DisableColliderForDuration()
    {
        // Collider deaktivieren
        gameCollider.enabled = false;

        // Warte für die definierte Dauer
        yield return new WaitForSeconds(disableDuration);

        // Collider wieder aktivieren
        gameCollider.enabled = true;
    }
}
