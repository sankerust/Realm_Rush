using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
  Waypoint nextWaypoint;
  [SerializeField] ParticleSystem finalExplosionFx;
  EnemySpawner enemySpawner;
    
    
    void Start()
    {
      enemySpawner = FindObjectOfType<EnemySpawner>();
      PathFinder pathfinder = FindObjectOfType<PathFinder>();
      var path = pathfinder.GetPath();
      StartCoroutine(FollowPath(path));
    }

  IEnumerator FollowPath(List<Waypoint> path)
  {
    foreach (Waypoint waypoint in path)
    {
        nextWaypoint = waypoint;
        yield return new WaitForSeconds(1 / (enemySpawner.EnemySpeed() / 10));
    }
    EnemyReachedEnd();
  }

  private void EnemyReachedEnd()
  {
    var reachedEndEffect = Instantiate(finalExplosionFx, transform.position, Quaternion.identity);
    reachedEndEffect.Play();

    Destroy(reachedEndEffect.gameObject, finalExplosionFx.main.duration);
    Destroy(gameObject);
  }

  void Update()
  {
    SmoothMovement();
    transform.LookAt(nextWaypoint.transform);

  }
  private void SmoothMovement()
  {
    float step = enemySpawner.EnemySpeed() * Time.deltaTime;
    transform.position = Vector3.MoveTowards(transform.position, nextWaypoint.transform.position, step);
  }
}
