using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

     public GameObject sword;
     public float speed = 2f;
     public float walkingAmplitude = 0.25f;
     public float walkingFrequency = 2.0f;
     public float swordRange = 2f;
     public float swordCooldown = 0.15f;

     public bool isDead = false;
     public bool hasCrossedFinishLine = false;

     public float cooldownTimer;
     private Vector3 swordTargetPosition;

     // Use this for initialization
     void Start()
     {
          swordTargetPosition = sword.transform.localPosition;
     }

     // Update is called once per frame
     void Update()
     {
          if (isDead)
          {
               return;
          }

          Debug.DrawRay(transform.position, Vector3.forward, Color.red);
          transform.position += Vector3.forward * speed * Time.deltaTime;
          transform.position = new Vector3(
               transform.position.x,
               0.5f + Mathf.Cos(transform.position.x * walkingFrequency) * walkingAmplitude,
               transform.position.z
          );

          cooldownTimer -= Time.deltaTime;

          if (GvrControllerInput.AppButtonDown || Input.GetMouseButtonDown(0))
          {
               RaycastHit hit;

               if (cooldownTimer <= 0f && Physics.Raycast(transform.position, transform.forward, out hit))
               {
                    cooldownTimer = swordCooldown;

                    Debug.Log("Hit enemy 2");

                    Debug.Log("Sword range: " + (hit.transform.position.z - this.transform.position.z));

                    if (hit.transform.GetComponent<Enemy>() != null && hit.transform.position.z - this.transform.position.z < swordRange)
                    {
                         Debug.Log("Hit enemy 3");
                         Destroy(hit.transform.gameObject);
                         swordTargetPosition = new Vector3(-swordTargetPosition.x, swordTargetPosition.y, swordTargetPosition.z);
                    }
               }
          }

          sword.transform.localPosition = Vector3.Lerp(sword.transform.localPosition, swordTargetPosition, Time.deltaTime * 15f);
     }

     void OnTriggerEnter(Collider collider)
     {
          if (collider.GetComponent<Enemy>() != null)
          {
               isDead = true;
          }
          else if (collider.tag == "FinishLine")
          {
               Debug.Log("Crossed finish line");

               hasCrossedFinishLine = true;
          }
     }
}
