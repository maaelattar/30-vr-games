using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCollisionArea : MonoBehaviour
{
     public Pin pin;
     private void OnTriggerEnter(Collider other)
     {
          if(other.tag == "Floor")
          {
               pin.OnTouchFloor();
          }
     }
}
