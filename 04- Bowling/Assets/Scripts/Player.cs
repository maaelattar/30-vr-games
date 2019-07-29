using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
     public GameObject bowlingBall;
     public Text infoText;
     public float ballDistance = 2.5f;
     public float ballThrowingForce = 200f;

     public bool holding = true;
     public int score = 0;

     // Update is called once per frame
     void Update()
     {
          if (holding)
          {
               bowlingBall.transform.position = transform.position + transform.forward * ballDistance;
               if (GvrControllerInput.AppButtonDown || Input.GetMouseButtonDown(0))
               {
                    holding = false;
                    bowlingBall.GetComponent<Rigidbody>().useGravity = true;
                    bowlingBall.GetComponent<Rigidbody>().AddForce(transform.forward * ballThrowingForce);
               }
          }
     }
}
