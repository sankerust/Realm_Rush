using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{

  int towerLimit = 5;
  [SerializeField] Tower towerPrefab;
  public Queue<Tower> towerQueue = new Queue<Tower>();
    public void AddTower(Waypoint baseWaypoint) {
      int numberOfTowersIngame = towerQueue.Count;

      if (numberOfTowersIngame < towerLimit) {
      InstantiateNewTower(baseWaypoint);
      } else {
        MoveExistingTower(baseWaypoint);
      }
    }

  private void InstantiateNewTower(Waypoint baseWaypoint)
  {
    var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);

    newTower.baseWaypoint= baseWaypoint;
    baseWaypoint.isPlaceable = false;
    towerQueue.Enqueue(newTower);
  }

  private void MoveExistingTower(Waypoint baseWaypoint)
  {
    var firstTower = towerQueue.Dequeue();
    firstTower.transform.position = baseWaypoint.transform.position;
    firstTower.baseWaypoint.isPlaceable = true;
    towerQueue.Enqueue(firstTower);
  }
}
