using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("headshot"))
        {
            // Zugriff auf den Roboter über das Elternobjekt (Root-Objekt)
            GameObject robot = collision.transform.root.gameObject;

            // Zerstöre den Roboter
            Destroy(robot);
        }
        if (collision.gameObject.CompareTag("bodyshot"))
        {
            // Zugriff auf den Roboter über das Elternobjekt (Root-Objekt)
            GameObject robot = collision.transform.root.gameObject;

            // Zerstöre den Roboter
            Destroy(robot);
        }
        if (collision.gameObject.CompareTag("footshot"))
        {
            // Zugriff auf den Roboter über das Elternobjekt (Root-Objekt)
            GameObject robot = collision.transform.root.gameObject;

            // Zerstöre den Roboter
            Destroy(robot);
        }

        // Zerstöre das Bullet-Objekt
        Destroy(gameObject);
    }
}

