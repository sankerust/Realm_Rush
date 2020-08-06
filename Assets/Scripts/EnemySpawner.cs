using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
  [Range(0.1f, 120f)][SerializeField] float secondsBetweenSpawn = 2f;
  [SerializeField] EnemyMovement enemyPrefab;
  [SerializeField] int unitCount;
  [SerializeField] Transform enemyParentTransform;
  [SerializeField] Text ScoreText;
  int spawnedEnemies = 0;
    void Start()
    {
      StartCoroutine(SpawnEnemyUnit());
      ScoreText.text = spawnedEnemies.ToString();
    }

  private IEnumerator SpawnEnemyUnit()
  {
    while (unitCount > 0)
    {
      var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
      newEnemy.transform.parent = enemyParentTransform;
      unitCount--;
      IncreaseScore();
      yield return new WaitForSeconds(secondsBetweenSpawn);
    }
  }

  private void IncreaseScore()
  {
    spawnedEnemies++;
    ScoreText.text = spawnedEnemies.ToString();
  }
}
