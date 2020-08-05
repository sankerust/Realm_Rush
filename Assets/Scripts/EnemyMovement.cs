using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
  Waypoint nextWaypoint;
  float enemySpeed = 10f;
    
    
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
        yield return new WaitForSeconds(1f);
    }

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
