using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
  [SerializeField] Transform objectToPan;
  [SerializeField] float attackRange = 10f;
  [SerializeField] ParticleSystem projectileParticle;
  [SerializeField] AudioClip shootSfx;
  AudioSource myAudioSource;
  Transform targetEnemy;
  public Waypoint baseWaypoint;
  void Start() {
    myAudioSource = GetComponent<AudioSource>();
  }
    void Update()
    {
      SetTargetEnemy();
      if (targetEnemy) {
        objectToPan.LookAt(targetEnemy);
        objectToPan.transform.Rotate(0, 270, 0);
        FireAtEnemy();
      } else {
        Shoot(false);
      }

    }

  private void SetTargetEnemy()
  {
    var sceneEnemies = FindObjectsOfType<EnemyDamage>();
    if (sceneEnemies.Length == 0) { return; }
    Transform closestEnemy = sceneEnemies[0].transform;
    
    foreach (EnemyDamage testEnemy in sceneEnemies) {
      closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
    }

    targetEnemy = closestEnemy;
  }

  private Transform GetClosest(Transform closestEnemy, Transform testEnemy)
  {
    var distanceToClosest = Vector3.Distance(closestEnemy.transform.position, gameObject.transform.position);
    var distanceToTest = Vector3.Distance(testEnemy.transform.position, gameObject.transform.position);
    if (distanceToTest < distanceToClosest) {
      return testEnemy;
    }
    return closestEnemy;
  }

  private void FireAtEnemy()
  {
     float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
     if (distanceToEnemy <= attackRange)
    {
      Shoot(true);
      PlayShootSound();
    }
    else {
       Shoot(false);
     }
  }

  private void PlayShootSound()
  {
    if (!myAudioSource.isPlaying) {
      //myAudioSource.Play();
    }
  }

  private void Shoot(bool isActive )
  {
    var emissionModule = projectileParticle.emission;
    emissionModule.enabled = isActive;
  }
}
