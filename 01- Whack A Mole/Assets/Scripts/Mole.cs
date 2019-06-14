using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
     private float visibleHeight = 2.27f;
     private float hiddenHeight = -4.0f;
     private float speed = 4.0f;
     private float disappearDuration = 1f;
     private float disappearTimer = 0f;

     private Vector3 targetPosition;
    // Start is called before the first frame update
    void Awake()
    {
        targetPosition = new Vector3(transform.localPosition.x, hiddenHeight, transform.localPosition.z);
        transform.localPosition = targetPosition;
     }

    // Update is called once per frame
    void Update()
    {
          disappearTimer -= Time.deltaTime;
          if(disappearTimer <= 0)
          {
               Hide();
          }

          transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, speed * Time.deltaTime);
    }

     public void Rise()
     {
          targetPosition = new Vector3(transform.localPosition.x, visibleHeight, transform.localPosition.z);
          disappearTimer = disappearDuration;
     }

     public void Hide()
     {
          targetPosition = new Vector3(transform.localPosition.x, hiddenHeight, transform.localPosition.z);
          
     }

  
}
