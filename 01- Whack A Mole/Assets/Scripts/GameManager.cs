using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
     [SerializeField]
     private GameObject moleContainer;

     [SerializeField]
     private TextMeshProUGUI scoreText;

     private float spawnCycle = 2f;
     private float spawnDecrement = 0.1f;
     private float minSpawnDuration = 0.5f;
     private float gameTimer = 60f;

     private Mole[] moles;
     private float spawnTimer = 0f;
     private float resetTimer = 4f;

     private int score;
    // Start is called before the first frame update
    void Start()
    {
          moles = moleContainer.GetComponentsInChildren<Mole>();
    }

    // Update is called once per frame
    void Update()
    {
          gameTimer -= Time.deltaTime;
          if(gameTimer > 0f)
          {
               scoreText.text = $"Score: {score}\nTime: {Math.Floor(gameTimer)}";
               spawnTimer -= Time.deltaTime;
               if(spawnTimer <= 0)
               {
                    
                    int index = UnityEngine.Random.Range(0, moles.Length);
                    Debug.Log("Mole index = " + index);
                    moles[index].Rise();
                    spawnCycle -= spawnDecrement;
                    if(spawnCycle <= 0)
                    {
                         spawnCycle = minSpawnDuration;
                    }
                    spawnTimer = spawnCycle;
               }
          }
          else
          {
               scoreText.text = $"Game Over\nScore: {score}";
               resetTimer -= Time.deltaTime;
               if (resetTimer <= 0f)
               {
                   SceneManager.LoadScene(SceneManager.GetActiveScene().name);

               }
          }
    }

     public void Hit()
     {
          score++;
     }

}
