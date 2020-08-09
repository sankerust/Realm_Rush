using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
  [Range(0.1f, 120f)][SerializeField] float secondsBetweenSpawn = 2f;
  [SerializeField] float enemySpeed = 10f;
  [SerializeField] int enemyHP = 10;
  [SerializeField] EnemyMovement enemyPrefab;
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

  public int EnemyHP()
  {
    return enemyHP;
  }

    private void IncreaseDifficulty() {
      if ((playerScore % 3) == 0 && enemySpeed <= 20) {
        enemySpeed = enemySpeed + 6;
      } else if (enemySpeed >= 20 && enemyHP <= 10) {
        enemyHP++;
      };
    }

  private IEnumerator SpawnEnemyUnit()
  {
    while (true) {
    GetComponent<AudioSource>().PlayOneShot(spawnedEnemySfx);
    var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    newEnemy.transform.parent = enemyParentTransform;
    yield return new WaitForSeconds(secondsBetweenSpawn);
    }
  }

}
