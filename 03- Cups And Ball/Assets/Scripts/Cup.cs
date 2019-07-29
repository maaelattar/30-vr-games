using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
     private float downHeight = 2.4f;
     private float upHeight = 2.6f;
     private float speed = 3f;

     public GameObject ball;

     public Vector3 targetPosition;

     // Start is called before the first frame update
     void Start()
     {
          targetPosition = transform.position;
     }

     // Update is called once per frame
     void Update()
     {
          transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

          if (ball != null)
          {
               ball.transform.position = new Vector3(
                    transform.position.x,
                    ball.transform.position.y,
                    transform.position.z
                    );
          }
     }

     public void MoveUp()
     {
          targetPosition = new Vector3(
               transform.position.x,
               upHeight,
               transform.position.z
               );
     }

     public void MoveDown()
     {
          targetPosition = new Vector3(
               transform.position.x,
               downHeight,
               transform.position.z
               );
     }
}
