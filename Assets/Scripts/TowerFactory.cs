using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{

  int towerLimit = 5;
  [SerializeField] Tower towerPrefab;
  [SerializeField] Transform towerParentTransform;
  [SerializeField] AudioClip towerPlacementSfx;
  AudioSource myAudioSource;
  private void Start()
  {
    myAudioSource = GetComponent<AudioSource>();
  }
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
    newTower.transform.parent = towerParentTransform;

    newTower.baseWaypoint= baseWaypoint;
    baseWaypoint.isPlaceable = false;
    towerQueue.Enqueue(newTower);
    AudioSource.PlayClipAtPoint(towerPlacementSfx, Camera.main.transform.position);
  }

  private void MoveExistingTower(Waypoint newBaseWaypoint)
  {
    var oldTower = towerQueue.Dequeue();
    oldTower.baseWaypoint.isPlaceable= true;
    oldTower.baseWaypoint = newBaseWaypoint;
    oldTower.transform.position = newBaseWaypoint.transform.position;
    towerQueue.Enqueue(oldTower);
  }
}
