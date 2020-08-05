﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
  [SerializeField] Tower towerPrefab;

  public bool isExplored = false;
  public bool isPlaceable = true;
  public Waypoint exploredFrom;
  const int gridSize = 10;
  Vector2Int gridPos;
    public int GetGridSize()
    {
      return gridSize;
    }
    public Vector2Int GetGridPos()
    {
      return new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize)
      );
    }

  void OnMouseOver() {
    if (Input.GetMouseButtonDown(0) && isPlaceable) {
      print(gameObject.name + " clicked");
      Instantiate(towerPrefab, transform.position, Quaternion.identity);
      isPlaceable = false;
    }
  }

}
