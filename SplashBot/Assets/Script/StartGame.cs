// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class StartGame : MonoBehaviour
// {
//     // Zeitintervall zwischen den Spawns (in Sekunden)
//     public float spawnInterval = 5.0f; 

//     public float startCountdown = 3.0f;

//     // Array mit verschiedenen Spawn-Radiussen
//     //public float[] spawnRadiuses; // muss mit voene, links und rechts befüllt werden

//     private Transform spawnCenter;

//     public float spawnRadius;
    
//     // Zeitversatz zum Entfernen des Objekts (in Sekunden)
//     public float despawnDelay = 30f; 

//     public GameObject bot;

//     // Start is called before the first frame update
//     void Start()
//     {
        
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

//     public void start()
// {
//     //Die Methode wird nach 3sekunden, jede 5 Sekunden ausgeführt
//              InvokeRepeating("SpawnBots", startCountdown,spawnInterval);
// }

//     private void SpawnBots()
//         {
            
                
//         float xRangeMin = spawnCenter.position.x + spawnRadius;
//         float xRangeMax = spawnCenter.position.x + spawnRadius;

//         float zRangeMin = spawnCenter.position.z + spawnRadius;
//         float zRangeMax = spawnCenter.position.z + spawnRadius;

//         float randomX = Random.Range(xRangeMin, xRangeMax);
//         float randomZ = Random.Range(zRangeMin, zRangeMax);

//         float randomY = Random.value > 0.5f ? 5f : 0f; // Zufällig 5 oder 0, um die Höhe festzulegen

//         Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

//         Instantiate(bot, spawnPosition, Quaternion.identity);

//                 // Starte den Despawn-Countdown
//                 Destroy(bot, despawnDelay);
        
//     }
// }


