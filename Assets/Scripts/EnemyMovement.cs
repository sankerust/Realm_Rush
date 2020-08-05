using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
  Waypoint nextWaypoint;
  [SerializeField] float enemySpeed = 10f;
  [SerializeField] ParticleSystem finalExplosionFx;
    
    
    void Start()
    {
      PathFinder pathfinder = FindObjectOfType<PathFinder>();
      var path = pathfinder.GetPath();
      StartCoroutine(FollowPath(path));
    }

  IEnumerator FollowPath(List<Waypoint> path)
  {
    foreach (Waypoint waypoint in path)
    {
        nextWaypoint = waypoint;
        yield return new WaitForSeconds(1 / (enemySpeed / 10));
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
    float step = enemySpeed * Time.deltaTime;
    transform.position = Vector3.MoveTowards(transform.position, nextWaypoint.transform.position, step);
  }
}
