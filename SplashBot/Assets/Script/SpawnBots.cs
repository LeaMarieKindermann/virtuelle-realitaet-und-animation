using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBots : MonoBehaviour
{
    public GameObject bot;

     // Zeitintervall zwischen den Spawns für feste bots (in Sekunden)
    public float spawnInterval = 5.0f; 

    public float startCountdown = 5.0f;

    
    // Für feste Bots
     public Transform[] spawnPoints;

     public Transform[] spawnPointsMove;

     public Transform[] deletePoints;


     public Transform lookAt;



     // Zeitversatz zum Entfernen des Objekts (in Sekunden)
     public float despawnDelay = 30f;


    // Damit spiel endet nach einer Zeit
    private bool spawnEnabled = true; 


    //Soundeffekte
    public AudioSource countdownSource;
    public AudioSource spawnSound;
    public AudioSource gameOver;


    //Animator
    Animator botAnimator;

    // soll bei collision mit dem Knopf aufgerufen werden
      public void StartSpawning()
    {
          spawnEnabled = true;
        
        // Damit das spiel nah 2min aufhört
        Invoke("DisableSpawn", 120f);

        // Spielt countdown
       countdownSource.Play();
        InvokeRepeating("SpawnBotsStand", startCountdown,spawnInterval);
        

        InvokeRepeating("SpawnAndMoveBots", 60f ,10f);

      
    }

    private void SpawnBotsStand()
        {
            
        if (!spawnEnabled)
            return;
        

        // Zufällig einen Spawnpunkt auswählen
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform selectedSpawnPoint = spawnPoints[randomIndex];
      

        // Position des ausgewählten Spawnpunkts verwenden
        Vector3 spawnPosition = selectedSpawnPoint.position;

         GameObject instantiatedBot = Instantiate(bot, spawnPosition, Quaternion.LookRotation(lookAt.position + spawnPosition));
         spawnSound.Play();
         botAnimator = instantiatedBot.GetComponent<Animator>();
        botAnimator.SetTrigger("disapear");
       

    


         if( instantiatedBot !=null){
           
            StartCoroutine(DeleteBotAfterTime(instantiatedBot, despawnDelay));
            

        }



    }

    private void SpawnAndMoveBots()
{
    if (!spawnEnabled)
            return;

            bool laufTag = false;


    // Zufällig einen Spawnpunkt auswählen
    int randomIndex = Random.Range(0, spawnPointsMove.Length);
    Transform selectedSpawnPoint = spawnPointsMove[randomIndex];

    // Position des ausgewählten Spawnpunkts verwenden
    Vector3 spawnPosition = selectedSpawnPoint.position;

    // Bot spawnen
    GameObject instantiatedBot = Instantiate(bot, spawnPosition,  Quaternion.LookRotation(lookAt.position + spawnPosition));

    botAnimator = instantiatedBot.GetComponent<Animator>();

    



    // Bot zu einem bestimmten Punkt bewegen
    Vector3 targetPosition = deletePoints[randomIndex].position ;
    float movementSpeed = 5f; // Beispielgeschwindigkeit, mit der sich der Bot bewegt

    botAnimator.SetTrigger("moving");
    StartCoroutine(MoveBot(instantiatedBot, targetPosition, movementSpeed));
    

}

private IEnumerator MoveBot(GameObject botToMove, Vector3 targetPosition, float speed)
{
    while (botToMove.transform.position != targetPosition && botToMove !=null)
    {
            if (botToMove != null)
            {
                // Bot zum Ziel bewegen
                botToMove.transform.position = Vector3.MoveTowards(botToMove.transform.position, targetPosition, speed * Time.deltaTime);
            }
        yield return null;
    }

    // Bot zerstören
    if(botToMove != null){
       Destroy(botToMove); 
    }
    
    
}

 private void DisableSpawn()
    {
        spawnEnabled = false; // Spawn deaktivieren

        // gameOver sound
        gameOver.Play();
    }

    

    

    private IEnumerator DeleteBotAfterTime(GameObject bot,  float delay){

        yield return new WaitForSeconds(20f);
        if(bot != null){
    
        botAnimator.SetTrigger("disapear");
        yield return new WaitForSeconds(5f);
        Destroy(bot, 3);
        }
    }
    
 

   
}
