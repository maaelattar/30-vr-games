using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
     private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
          initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
          transform.position = Vector3.Lerp(initialPosition, transform.position, Time.deltaTime);
    }

     public void Hit(Vector3 targetPosition)
     {
          transform.position = targetPosition;
     } 
     
}
