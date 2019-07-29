﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

     public GameObject[] models;

     // Use this for initialization
     void Start()
     {
          int randomIndex = Random.Range(0, models.Length);
          for (int i = 0; i < models.Length; i++)
          {
               models[i].SetActive(i == randomIndex);
          }
     }

     
}
