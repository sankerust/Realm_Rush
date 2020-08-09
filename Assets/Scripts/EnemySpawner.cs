using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
  [Range(0.1f, 120f)][SerializeField] float secondsBetweenSpawn = 2f;
  [SerializeField] float enemySpeed = 10f;
  [SerializeField] EnemyMovement enemyPrefab;
  [SerializeField] int unitCount;
  [SerializeField] Transform enemyParentTransform;
  [SerializeField] Text ScoreText;
  [SerializeField] AudioClip spawnedEnemySfx;
  int playerScore = 0;
    void Start()
    {
      StartCoroutine(SpawnEnemyUnit());
      ScoreText.text = "Tanks destroyed: " + playerScore.ToString();
    }
    public void IncreaseScore() {
      playerScore++;
      ScoreText.text = "Tanks destroyed: " + playerScore.ToString();
      IncreaseDifficulty();
    }
    
    public float EnemySpeed() {
      return enemySpeed;
    }

    private void IncreaseDifficulty() {
      if ((playerScore % 3) == 0) {
        enemySpeed = enemySpeed + 3;
      } else if (enemySpeed >= 30) {
        secondsBetweenSpawn++;
      };
    }

  private IEnumerator SpawnEnemyUnit()
  {
    while (unitCount > 0)
    {
      GetComponent<AudioSource>().PlayOneShot(spawnedEnemySfx);
      var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
      newEnemy.transform.parent = enemyParentTransform;
      unitCount--;
      yield return new WaitForSeconds(secondsBetweenSpawn);
    }
  }

}
