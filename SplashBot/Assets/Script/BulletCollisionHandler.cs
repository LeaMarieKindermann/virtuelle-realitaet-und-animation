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

                DestroyWithAnimation(robot);

            }
            // Zerstöre das Bullet-Objekt
            Destroy(gameObject);
        
    }

    private void DestroyWithAnimation(GameObject robot)
    {
        botAnimator = robot.GetComponent<Animator>();
        botAnimator.SetTrigger("fall");
        Destroy(robot, 1.2f);
    }
}
