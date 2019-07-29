using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
     public Player player;
     public BallCollider ballCollider;

     public Text infoText;
     public Pin[] pins;

     private float resetTimer = 5;

     private void Update()
     {
          infoText.text = "Throw the bowling ball";

          if (player.holding == false)
          {
               infoText.text = "Your score: " + player.score;
          }

             
            if(ballCollider.hitWall == true)
          {
               resetTimer -= Time.deltaTime;
               infoText.text += $"\nRestarting game in: {Mathf.Ceil(resetTimer)}";
               if (resetTimer <= 0)
               {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
               }
          }
               
          }
     }
