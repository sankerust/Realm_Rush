using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  [SerializeField] float secondsBetweenSpawn = 2f;
  [SerializeField] EnemyMovement enemyPrefab;
  [SerializeField] int unitCount;
    void Start()
    {
      StartCoroutine(SpawnEnemyUnit());
    }

  private IEnumerator SpawnEnemyUnit()
  {
    while (unitCount > 0) {
      Instantiate(enemyPrefab);
      unitCount--;
      yield return new WaitForSeconds(secondsBetweenSpawn);
    }
  }
}
