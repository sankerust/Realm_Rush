﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
  [SerializeField] int playerHP = 5;
  [SerializeField] Text healthText;

  private void Start() {
    healthText.text =  playerHP.ToString();
  }
    private void OnTriggerEnter(Collider other) {
      playerHP--;
      healthText.text = playerHP.ToString();
      print(playerHP);
    }
}
