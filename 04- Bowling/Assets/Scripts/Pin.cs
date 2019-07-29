using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
     Player player;
     private void Awake()
     {
           player = GameObject.Find("Player").GetComponent<Player>();
     }
     public void OnTouchFloor()
     {
          Destroy(gameObject);
          player.score++;
     }

   

}
