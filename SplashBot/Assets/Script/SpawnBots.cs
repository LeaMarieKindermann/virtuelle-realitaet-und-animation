using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBots : MonoBehaviour
{
    public GameObject bot;

     // Zeitintervall zwischen den Spawns für feste bots (in Sekunden)
    public float spawnInterval = 5.0f; 

    public float startCountdown = 3.0f;

    
    // Für feste Bots
     public Transform[] spawnPoints;

     public Transform[] spawnPointsMove;

     public Transform[] deletePoints;


     public Transform lookAt;



     // Zeitversatz zum Entfernen des Objekts (in Sekunden)
     public float despawnDelay = 30f;


    // Damit spiel endet nach einer Zeit
    private bool spawnEnabled = true; 


    // Punkte
    public long score = 0;


    // Start is called before the first frame update
    void Start()
    {
       
        

        // Damit das speil nah 2min aufhört
        Invoke("DisableSpawn", 120f);


       
        InvokeRepeating("SpawnBotss", startCountdown,spawnInterval);

        InvokeRepeating("SpawnAndMoveBots", 60f ,10f);
        
        
    }

    private void SpawnBotss()
        {
            
        if (!spawnEnabled)
            return;
        // Zufällig einen Spawnpunkt auswählen
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform selectedSpawnPoint = spawnPoints[randomIndex];

        // Position des ausgewählten Spawnpunkts verwenden
        Vector3 spawnPosition = selectedSpawnPoint.position;

         GameObject instantiatedBot = Instantiate(bot, spawnPosition, Quaternion.LookRotation(lookAt.position - spawnPosition));
 
                // Starte den Despawn-Countdown
                Destroy(instantiatedBot, despawnDelay);
                score = score + 10;
        
    }

    private void SpawnAndMoveBots()
{
    if (!spawnEnabled)
            return;
    // Zufällig einen Spawnpunkt auswählen
    int randomIndex = Random.Range(0, spawnPointsMove.Length);
    Transform selectedSpawnPoint = spawnPointsMove[randomIndex];

    // Position des ausgewählten Spawnpunkts verwenden
    Vector3 spawnPosition = selectedSpawnPoint.position;

    // Bot spawnen
    GameObject instantiatedBot = Instantiate(bot, spawnPosition,  Quaternion.LookRotation(lookAt.position - spawnPosition));

    // Bot zu einem bestimmten Punkt bewegen
    Vector3 targetPosition = deletePoints[randomIndex].position ;
    float movementSpeed = 5f; // Beispielgeschwindigkeit, mit der sich der Bot bewegt

    StartCoroutine(MoveBot(instantiatedBot, targetPosition, movementSpeed));
}

private IEnumerator MoveBot(GameObject botToMove, Vector3 targetPosition, float speed)
{
    while (botToMove.transform.position != targetPosition)
    {
        // Bot zum Ziel bewegen
        botToMove.transform.position = Vector3.MoveTowards(botToMove.transform.position, targetPosition, speed * Time.deltaTime);

        yield return null;
    }

    // Bot zerstören
    Destroy(botToMove);
    score = score + 20;
}

 private void DisableSpawn()
    {
        spawnEnabled = false; // Spawntimer deaktivieren
    }

    // Kann von wo anders aufgerufen werden 
      public void StartSpawning()
    {
        spawnEnabled = true;

        score = 0;
    }

   
}
