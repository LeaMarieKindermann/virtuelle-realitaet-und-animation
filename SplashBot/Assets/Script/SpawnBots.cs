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


    // Punkte
    //DELETE?
    public long score = 0;

    //Soundeffekt countdown
    public AudioSource countdownSource;
    public AudioSource fallSound;
    public AudioSource spawnSound;

    //Animator
    Animator botAnimator;


    // delete
    void Start()
    {
       
        

        // Damit das speil nah 2min aufhört
        Invoke("DisableSpawn", 120f);


        countdownSource.Play();
        InvokeRepeating("SpawnBotsStand", startCountdown,spawnInterval);

        InvokeRepeating("SpawnAndMoveBots", 60f ,10f);
        
        
    }

    // soll bei collision mit dem Knopf aufgerufen werden
      public void StartSpawning()
    {
          spawnEnabled = true;
        //DELETE?
        score = 0;

        
        // Damit das speil nah 2min aufhört
        Invoke("DisableSpawn", 120f);

        // Speilt counddown
       countdownSource.Play();
        InvokeRepeating("SpawnBotsStand", startCountdown,spawnInterval);
        

        InvokeRepeating("SpawnAndMoveBots", 60f ,10f);

      
    }

    private void SpawnBotsStand()
        {
            
        if (!spawnEnabled)
            return;
        //DELETE
           // bool laufTag = false;

        // Zufällig einen Spawnpunkt auswählen
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform selectedSpawnPoint = spawnPoints[randomIndex];
        //Todo delete
        //Transform selectedSpawnPoint = spawnPoints[1];

        // Position des ausgewählten Spawnpunkts verwenden
        Vector3 spawnPosition = selectedSpawnPoint.position;

         GameObject instantiatedBot = Instantiate(bot, spawnPosition, Quaternion.LookRotation(lookAt.position + spawnPosition));
         spawnSound.Play();
         botAnimator = instantiatedBot.GetComponent<Animator>();
        botAnimator.SetTrigger("disapear");
       

    


         if( instantiatedBot !=null){
            // lambafunktion als Wrapper  um das bot objekt zu übergeben
            // System.Action deleteBotAction = () => deleteBotAfterTime(instantiatedBot);
            //Invoke("deleteBotAction", despawnDelay);
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
        // Bot zum Ziel bewegen
        botToMove.transform.position = Vector3.MoveTowards(botToMove.transform.position, targetPosition, speed * Time.deltaTime);

        yield return null;
    }

    // Bot zerstören
    if(botToMove != null){
       Destroy(botToMove); 
    }
    
    
}

 private void DisableSpawn()
    {
        spawnEnabled = false; // Spawntimer deaktivieren
    }

    

    

    private IEnumerator DeleteBotAfterTime(GameObject bot,  float delay){

        yield return new WaitForSeconds(20f);
        if(bot != null){
    
        botAnimator.SetTrigger("disapear");
        yield return new WaitForSeconds(5f);
        Destroy(bot, 3);
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {

        

        if (collision.gameObject.CompareTag("bot"))
        {
            botAnimator.SetTrigger("fall");
            fallSound.Play();
            Destroy(collision.gameObject,1.2f);
            Debug.Log("Bot zerstört");
        }
        else if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Bullet zerstört");
        }
        else
        {
            Debug.Log("Kollision mit unbekanntem Objekt");
        }
    }

   


   
}
