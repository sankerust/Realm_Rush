using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
  [SerializeField] GameObject hitFx;
  [SerializeField] int hitsToDie;

    // Start is called before the first frame update
    void Start()
    {
    }

   private void OnParticleCollision(GameObject other) {
      print("particle collision");
      GameObject enemyHitFx = Instantiate(hitFx, transform.position, Quaternion.identity);
      hitsToDie--;
      if (hitsToDie <= 1) {
        Destroy(gameObject);
      }
      //enemyHitFx.transform.parent = parent;
    }
}
