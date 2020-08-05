using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  [SerializeField] int playerHP = 5;
    private void OnTriggerEnter(Collider other) {
      playerHP--;
    }
}
