using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
  [SerializeField] ParticleSystem enemyHitFx;
  [SerializeField] ParticleSystem enemyDeathFx;
  [SerializeField] int hitPoints = 15;

   private void OnParticleCollision(GameObject other) {
      ProcessHit();
      if (hitPoints <= 0)
      {
        KillEnemy();
      }
    }
    private void KillEnemy()
    {
      var deathEffect = Instantiate(enemyDeathFx, transform.position, Quaternion.identity);
      deathEffect.Play();

      float particleDestroyDelay = deathEffect.main.duration;
      Destroy(deathEffect.gameObject, particleDestroyDelay);
      Destroy(gameObject);
    }
    private void ProcessHit()
    {
      enemyHitFx.Play();
      hitPoints--;
    }
}
