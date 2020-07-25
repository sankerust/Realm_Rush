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
  Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
  Queue<Waypoint> queue = new Queue<Waypoint>();
  bool isRunning = true;
  Waypoint searchCenter;
    // Start is called before the first frame update
    void Start()
    {
      ColorStartAndEnd();
      LoadBlocks();
      PathFind();
      //ExploreNeighbours();
    }

  private void PathFind()
  {
    queue.Enqueue(startWaypoint);
    while (queue.Count > 0 && isRunning) {
      searchCenter = queue.Dequeue();
      searchCenter.isExplored = true;
      HaltIfEndFound();
      ExploreNeighbours();
    }
    print("Finished");
  }

  private void HaltIfEndFound()
  {
    if (searchCenter == endWaypoint) {
      print("Found the end");
      isRunning = false;
    }
  }

  private void ExploreNeighbours()
  {
    if (!isRunning) { return; }
    foreach (Vector2Int direction in directions)
    {
      Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
      try
      {
        QueueNewNeighbours(neighbourCoordinates);
      }
      catch {
        
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
  {
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
