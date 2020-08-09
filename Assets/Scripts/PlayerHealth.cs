using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
  [SerializeField] int playerHP = 100;
  [SerializeField] Text healthText;
  [SerializeField] AudioClip reachedBaseSfx;
  int healthDecrease = 10;

  private void Start() {
    healthText.text =  "Base integrity: " + playerHP.ToString() + "%";
  }
    private void OnTriggerEnter(Collider other) {
      GetComponent<AudioSource>().PlayOneShot(reachedBaseSfx);
      playerHP -= healthDecrease;
      healthText.text = "Base integrity: " + playerHP.ToString() + "%";
    }
}
