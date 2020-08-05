using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  [Range(0.1f, 120f)][SerializeField] float secondsBetweenSpawn = 2f;
  [SerializeField] EnemyMovement enemyPrefab;
  [SerializeField] int unitCount;
  [SerializeField] Transform enemyParentTransform;
    void Start()
    {
      StartCoroutine(SpawnEnemyUnit());
    }

  private IEnumerator SpawnEnemyUnit()
  {
    while (unitCount > 0) {
      var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
      newEnemy.transform.parent = enemyParentTransform;
      unitCount--;
      yield return new WaitForSeconds(secondsBetweenSpawn);
    }
  }
}
