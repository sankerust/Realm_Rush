using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
  [SerializeField] ParticleSystem enemyHitFx;
  [SerializeField] ParticleSystem enemyDeathFx;
  [SerializeField] int hitPoints = 15;
  [SerializeField] AudioClip enemyExplosionSfx;
  [SerializeField] AudioClip enemyHitSfx;
  AudioSource myAudioSource;
  private void Start() {
    myAudioSource = GetComponent<AudioSource>();
  }
   private void OnParticleCollision(GameObject other) {
      ProcessHit();
      if (hitPoints <= 0)
      {
        KillEnemy();
      }
    }
  private void KillEnemy()
  {
    FindObjectOfType<EnemySpawner>().IncreaseScore();
    var deathEffect = Instantiate(enemyDeathFx, transform.position, Quaternion.identity);
    deathEffect.Play();
    Destroy(deathEffect.gameObject, deathEffect.main.duration);
    AudioSource.PlayClipAtPoint(enemyExplosionSfx, Camera.main.transform.position);
    Destroy(gameObject);
  }
  private void ProcessHit()
  {
    hitPoints--;
    PlayHitEffects();
  }

  private void PlayHitEffects()
  {
    myAudioSource.PlayOneShot(enemyHitSfx);
    var hitEffect = Instantiate(enemyHitFx, transform.position, Quaternion.identity);
    hitEffect.Play();

    float particleDestroyDelay = hitEffect.main.duration;
    Destroy(hitEffect.gameObject, particleDestroyDelay);
  }
}
