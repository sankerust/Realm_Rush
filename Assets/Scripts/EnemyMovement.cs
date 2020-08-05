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
        //transform.position = waypoint.transform.position; //obsolete
        nextWaypoint = waypoint;
        yield return new WaitForSeconds(1f);
    }

  }
  void Update()
  {
    SmoothMovement();
  }

  private void SmoothMovement() //remove completely and uncomment FollowPath to revert
  {
    float step = enemySpeed * Time.deltaTime;
    transform.position = Vector3.MoveTowards(transform.position, nextWaypoint.transform.position, step);
  }
}
