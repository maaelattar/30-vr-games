using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
     public TextMeshProUGUI infoText;
     public Player player;

     private float gameTimer = 0f;
     private float resetTimer = 6f;
    // Update is called once per frame
    void Update()
    {
          if(player.reachedFinishLine == false)
          {
               gameTimer += Time.deltaTime;
               infoText.text = $"Avoid the obstacles\nPress button to jump\n\nTime: {Mathf.Floor(gameTimer)}";
          }
          else
          {
               infoText.text = $"You win\nYour time is: {Mathf.Floor(gameTimer)}\nRestarting game in: {Mathf.Floor(resetTimer)}";
               resetTimer -= Time.deltaTime;
               if(resetTimer <= 0f)
               {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
               }
          }
     }
}
