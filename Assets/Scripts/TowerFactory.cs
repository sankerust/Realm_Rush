using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
  [SerializeField] int towerLimit = 5;
  [SerializeField] Tower towerPrefab;
    public void AddTower(Waypoint baseWaypoint) {
      int numberOfTowersIngame = FindObjectsOfType<Tower>().Length;
      if (numberOfTowersIngame < towerLimit) {
      InstantiateNewTower(baseWaypoint);
      } else {
        MoveExistingTower();
      }
    }

  private void MoveExistingTower()
  {
    throw new NotImplementedException();
  }

  private void InstantiateNewTower(Waypoint baseWaypoint)
  {
    Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
    baseWaypoint.isPlaceable = false;
  }
}
