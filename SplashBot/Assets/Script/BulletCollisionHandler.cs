using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    private Animator botAnimator;

    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.CompareTag("headshot") ||
                collision.gameObject.CompareTag("bodyshot") ||
                collision.gameObject.CompareTag("footshot"))
            {
                // Zugriff auf den Roboter über das Elternobjekt (Root-Objekt)
                GameObject robot = collision.transform.root.gameObject;
               // robot.collider.enabled = false;
                DestroyWithAnimation(robot);

            }
            // Zerstöre das Bullet-Objekt
            Destroy(gameObject);
        
    }

    private void DestroyWithAnimation(GameObject robot)
    {
        botAnimator = robot.GetComponent<Animator>();
        botAnimator.SetTrigger("fall");

        Collider[] colliders = robot.GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = false; 
        }

        Destroy(robot, 1.2f);
    }
}
