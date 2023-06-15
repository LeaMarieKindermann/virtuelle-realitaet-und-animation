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
//TODO delete
    //id
    //private long id = 0;

    //Animator
    Animator botAnimator;

    // Start is called before the first frame update
    void Start()
    {
       
        

        // Damit das speil nah 2min aufhört
        Invoke("DisableSpawn", 120f);


       
        InvokeRepeating("SpawnBotsStand", startCountdown,spawnInterval);

        InvokeRepeating("SpawnAndMoveBots", 60f ,10f);
        
        
    }

    private void SpawnBotsStand()
        {
            
        if (!spawnEnabled)
            return;

            bool laufTag = false;

        // Zufällig einen Spawnpunkt auswählen
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform selectedSpawnPoint = spawnPoints[randomIndex];
        //Todo delete
        //Transform selectedSpawnPoint = spawnPoints[1];

        // Position des ausgewählten Spawnpunkts verwenden
        Vector3 spawnPosition = selectedSpawnPoint.position;

         GameObject instantiatedBot = Instantiate(bot, spawnPosition, Quaternion.LookRotation(lookAt.position + spawnPosition));
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
    while (botToMove.transform.position != targetPosition)
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

    // Kann von wo anders aufgerufen werden 
      public void StartSpawning()
    {
        spawnEnabled = true;

        score = 0;
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

        if(collision.gameObject.CompareTag("joined")){
            return;
        }

        if (collision.gameObject.CompareTag("bot"))
        {
            botAnimator.SetTrigger("fall");
            Destroy(collision.gameObject);
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
