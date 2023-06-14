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

        //Hitbox erstellen
         instantiatedBot = CreateHitbox( instantiatedBot, laufTag);
 
          
        /* if( instantiatedBot !=null){
            // lambafunktion als Wrapper  um das bot objekt zu übergeben
             System.Action deleteBotAction = () => deleteBotAfterTime(instantiatedBot);
            Invoke(deleteBotAction, despawnDelay);
        }*/
                
                
        
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
    GameObject instantiatedBot = Instantiate(bot, spawnPosition,  Quaternion.LookRotation(lookAt.position - spawnPosition));

   //Hitbox erstellen
         instantiatedBot = CreateHitbox( instantiatedBot, laufTag); 



    // Bot zu einem bestimmten Punkt bewegen
    Vector3 targetPosition = deletePoints[randomIndex].position ;
    float movementSpeed = 5f; // Beispielgeschwindigkeit, mit der sich der Bot bewegt

    StartCoroutine(MoveBot(instantiatedBot, targetPosition, movementSpeed));
   // botAnimator.SetBool("IsMoving", false);

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

    private GameObject CreateHitbox( GameObject bot, bool laufTag){

        // die physik
        Rigidbody rb = bot.AddComponent<Rigidbody>();
        rb.mass = 5.0f;
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezePositionY;


       MeshFilter meshFilter = bot.GetComponent<MeshFilter>();
    if (meshFilter != null)
    {
        MeshCollider meshCollider = bot.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = meshFilter.sharedMesh;
        // Setze den Tag für die Hitbox
        if(laufTag){
            meshCollider.gameObject.tag = "Hitbox20";
        }
        else{
             meshCollider.gameObject.tag = "Hitbox10";
        }
       
    }


        return bot;


    }

    private void deleteBotAfterTime(GameObject bot){

        Destroy( bot);

    }

private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Hitbox10"))
    {
        HandleHitboxCollision(collision.gameObject, 10);
    }

    if (collision.gameObject.CompareTag("Hitbox20"))
    {
        HandleHitboxCollision(collision.gameObject, 20);
    }
}

private void HandleHitboxCollision(GameObject bot, int scoreToAdd)
{
    //  Animation abspielen.

    // Kollision mit der Hitbox
    Destroy(bot); // Zerstöre das kollidierende GameObject (den Bot)
    score += scoreToAdd;
}


   
}
