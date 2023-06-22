using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
    
{
    
     Animator botAnimator;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("headshot"))
        {
            // Zugriff auf den Roboter über das Elternobjekt (Root-Objekt)
            GameObject robot = collision.transform.root.gameObject;
            botAnimator = robot.GetComponent<Animator>();

            botAnimator.SetTrigger("fall");
            
            Destroy(robot, 1.2f);

            // Zerstöre den Roboter
            //Destroy(robot);
        }
        if (collision.gameObject.CompareTag("bodyshot"))
        {
            // Zugriff auf den Roboter über das Elternobjekt (Root-Objekt)
            GameObject robot = collision.transform.root.gameObject;
            
            botAnimator = robot.GetComponent<Animator>();

            botAnimator.SetTrigger("fall");
           // fallSound.Play();
            Destroy(robot, 0.7f);
        }
        if (collision.gameObject.CompareTag("footshot"))
        {
            // Zugriff auf den Roboter über das Elternobjekt (Root-Objekt)
            GameObject robot = collision.transform.root.gameObject;

            
            botAnimator = robot.GetComponent<Animator>();

            botAnimator.SetTrigger("fall");
            //fallSound.Play();
            Destroy(robot, 0.7f);
        }

        // Zerstöre das Bullet-Objekt
        Destroy(gameObject);
    }
}

