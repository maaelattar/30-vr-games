using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     public float maximumSpeed = 5.5f;
     public float accelaration = 1f;
     public float jumpingForce = 450f;
     public float jumpingCoolDown = 0.6f;

     public bool reachedFinishLine = false;

     public float speed = 0;
     public float jumpingTimer = 0;

     private bool canJump = true;

     // Update is called once per frame
     void Update()
    {
          if(reachedFinishLine == false)
          {
               speed += accelaration * Time.deltaTime;
               if (speed >= maximumSpeed)
               {
                    speed = maximumSpeed;
               }
               transform.position += Vector3.forward * speed * Time.deltaTime;
               jumpingTimer -= Time.deltaTime;
               if (GvrControllerInput.ClickButtonDown || Input.GetKeyDown(KeyCode.Space))
               {
                    if (jumpingTimer <= 0 && canJump == true)
                    {
                         jumpingTimer = jumpingCoolDown;
                         GetComponent<Rigidbody>().AddForce(Vector3.up * jumpingForce);

                    }
               }
          }
      


    }
     void OnTriggerEnter(Collider other)
     {
          if(other.tag == "Obstacle")
          {
               speed *= 0.3f;
          }

          if(other.tag == "FinishLine")
          {
               reachedFinishLine = true;
          }
          if(other.tag == "Last_Obstacle")
          {
               canJump = false;
               Debug.Log("Player can't jump");
          }
     }

}
