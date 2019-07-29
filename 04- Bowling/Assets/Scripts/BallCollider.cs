using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollider : MonoBehaviour
{
     public bool hitWall = false;

     private void OnTriggerEnter(Collider other)
     {
          if(other.tag == "Ball")
          {
               hitWall = true;
          }
     }
}
