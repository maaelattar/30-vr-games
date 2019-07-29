using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     public bool canPick = false;
     public bool picked = false;
     public bool won = false;

     private void Update()
     {
          if (canPick)
          {
               if (GvrControllerInput.AppButtonDown || Input.GetMouseButtonDown(0))
               {
                    Debug.Log("GvrControllerButton.App: " + GvrControllerButton.App.ToString());
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                    {
                         Cup cup = hit.transform.GetComponent<Cup>();
                         if (cup != null)
                         {
                              canPick = false;
                              picked = true;

                              won = (cup.ball != null);

                              cup.MoveUp();
                         }
                    }

               }
          }


     }
}