using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
  [SerializeField] GameObject hitFx;
  [SerializeField] int hitPoints = 15;

    // Start is called before the first frame update
    void Start()
    {
    }
   private void OnParticleCollision(GameObject other) {
      print("particle collision");
      GameObject enemyHitFx = Instantiate(hitFx, transform.position, Quaternion.identity);
      ProcessHit();
      if (hitPoints <= 1)
      {
        KillEnemy();
      }
      //enemyHitFx.transform.parent = parent;
    }
    private void KillEnemy()
    {
      Destroy(gameObject);
    }
    private void ProcessHit()
    {
      hitPoints--;
    }
}
