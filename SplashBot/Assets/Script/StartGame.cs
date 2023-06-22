using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public SpawnBots startGame;
    public TimerScript timer;

    private void OnCollisionEnter(Collision collision)
    {
        // Überprüfe, ob der Collider mit dem gewünschten Tag getroffen wurde
        if (collision.collider.CompareTag("bullet"))
        {
            Debug.Log("RUFT AUF");

            // Überprüfe, ob startGame und timer nicht null sind, bevor die Methoden aufgerufen werden
            if (startGame != null && timer != null)
            {
                startGame.StartSpawning();
                Invoke("StartTimerDelayed", 5f);
            }
        }
    }

    private void StartTimerDelayed()
    {
        timer.StartTimer();
    }
}
