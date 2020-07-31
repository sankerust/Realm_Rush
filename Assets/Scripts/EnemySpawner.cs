using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  [Range(0.1f, 120f)][SerializeField] float secondsBetweenSpawn = 2f;
  [SerializeField] EnemyMovement enemyPrefab;
  [SerializeField] int unitCount;
    void Start()
    {
      StartCoroutine(SpawnEnemyUnit());
    }

  private IEnumerator SpawnEnemyUnit()
  {
    while (unitCount > 0) {
      Instantiate(enemyPrefab, transform.position, Quaternion.identity);
      unitCount--;
      yield return new WaitForSeconds(secondsBetweenSpawn);
    }
  }
}
