using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public SpawnBots startGame;
    //private TimerScript timer;

    /* private void Start()
    {
        timer = GetComponent<TimerScript>();
    } */

    private void OnCollisionEnter(Collision collision)
    {
        // Überprüfe, ob der Collider mit dem gewünschten Tag getroffen wurde
        if (collision.collider.CompareTag("bullet"))
        {
            Debug.Log("RUFT AUF");

            // Überprüfe, ob startGame nicht null ist, bevor die Methode aufgerufen wird
            if (startGame != null)
            {
                startGame.StartSpawning();
                //timer.StartTimer();
            }
        }
    }
}
