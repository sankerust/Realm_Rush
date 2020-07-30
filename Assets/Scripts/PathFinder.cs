﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
  [SerializeField] Waypoint startWaypoint, endWaypoint;
  Vector2Int [] directions = {
    Vector2Int.up,
    Vector2Int.right,
    Vector2Int.down,
    Vector2Int.left
  };
  public List<Waypoint> GetPath() 
  {
    if (path.Count == 0)
    {
      CalculatePath();
    }
    return path;
  }

  private void CalculatePath()
  {
    ColorStartAndEnd();
    LoadBlocks();
    BreadthFirstSearch();
    FormThePath();
  }

  Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
  Queue<Waypoint> queue = new Queue<Waypoint>();
  bool isRunning = true;
  Waypoint searchCenter;
  List<Waypoint> path = new List<Waypoint>();
  private void FormThePath()
  {
    path.Add(endWaypoint);

    Waypoint previous = endWaypoint.exploredFrom;
    while ( previous != startWaypoint) {
      path.Add(previous);
      previous = previous.exploredFrom;
    }
    path.Add(startWaypoint);
    path.Reverse();
  }

  private void BreadthFirstSearch()
  {
    queue.Enqueue(startWaypoint);
    while (queue.Count > 0 && isRunning) {
      searchCenter = queue.Dequeue();
      searchCenter.isExplored = true;
      HaltIfEndFound();
      ExploreNeighbours();
    }
  }

  private void HaltIfEndFound()
  {
    if (searchCenter == endWaypoint) {
      isRunning = false;
    }
  }

  private void ExploreNeighbours()
  {
    if (!isRunning) { return; }
    foreach (Vector2Int direction in directions)
    {
      Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
      if (grid.ContainsKey(neighbourCoordinates))
      {
        QueueNewNeighbours(neighbourCoordinates);
      }
    }
  }

  private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
  {
    Waypoint neighbour = grid[neighbourCoordinates];
    if (neighbour.isExplored || queue.Contains(neighbour)) {
      // do nothing
    } else {
      queue.Enqueue(neighbour);
      neighbour.exploredFrom = searchCenter;
    }
  }

  private void ColorStartAndEnd()
  { // todo maybe move fro mstart
    startWaypoint.SetTopColor(Color.green);
    endWaypoint.SetTopColor(Color.red);
  }

  public void LoadBlocks()
    {
      var waypoints = FindObjectsOfType<Waypoint>();
      foreach (Waypoint waypoint  in waypoints)
      {
        var gridPos = waypoint.GetGridPos();
        if (grid.ContainsKey(gridPos)) {
          Debug.LogWarning("Overlapping block " + waypoint);
        } else {
          grid.Add(gridPos, waypoint);
        }
        //print("Loaded " + grid.Count + " blocks");
        
      }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
