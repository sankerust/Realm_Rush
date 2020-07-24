using System;
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
    // Start is called before the first frame update
    void Start()
    {
      ColorStartAndEnd();
      LoadBlocks();
      ExploreNeighbours();
    }

  private void ExploreNeighbours()
  {
    foreach (Vector2Int direction in directions)
    {
      Vector2Int explorationCoordinates = direction + startWaypoint.GetGridPos();
      try {
        grid[explorationCoordinates].SetTopColor(Color.blue);
      } catch {
        print("no grid element");
      }
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
        print("Loaded " + grid.Count + " blocks");
        
      }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
