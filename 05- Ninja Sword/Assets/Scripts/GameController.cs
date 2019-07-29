using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

     public Text infoText;
     public Player player;

     private float restartTimer = 2f;

     // Use this for initialization
     void Awake()
     {
          infoText.text = "Race to the finish!";
     }

     // Update is called once per frame
     void Update()
     {
          if (player.isDead)
          {
               infoText.text = "You lost";

               restartTimer -= Time.deltaTime;
               if (restartTimer <= 0f)
               {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
               }
          }
          else if (player.hasCrossedFinishLine)
          {
               infoText.text = "You won!\nCongratulations";

               restartTimer -= Time.deltaTime;
               if (restartTimer <= 0f)
               {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
               }
          }
     }
}
