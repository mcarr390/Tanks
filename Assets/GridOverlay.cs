using System;
using UnityEngine;
using UnityEditor;

public class GridOverlay : MonoBehaviour
{
    
    int gridSize = 50; // Size of the grid (from -100 to 100)

    Vector3 startXPosition;
    Vector3 endXPosition;
    Vector3 startZPosition;
    Vector3 endZPosition;
    void Awake()
    {
        startXPosition = Vector3.zero + new Vector3(-gridSize, 0, -gridSize);
        endXPosition = Vector3.zero + new Vector3(gridSize, 0, -gridSize);
        
        startZPosition = Vector3.zero + new Vector3(-gridSize, 0, -gridSize);
        endZPosition = Vector3.zero + new Vector3(-gridSize, 0, gridSize);

    }

    private void OnDrawGizmos()
    {

        for (int i = 0; i < gridSize * 2; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(startXPosition + (Vector3.forward * i), endXPosition + (Vector3.forward * i));
        }
        
        for (int i = 0; i < gridSize * 2; i++)
        {
            Gizmos.color = Color.blue;

            Gizmos.DrawLine(startZPosition + (Vector3.right * i), endZPosition + (Vector3.right * i));
        }

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                
            }
        }
        

        // Vector3 startPoint = transform.position - Vector3.right * gridSize / 2 * cellSize - Vector3.forward * gridSize / 2 * cellSize;
        //
        // for (int x = -gridSize / 2; x <= gridSize / 2; x++)
        // {
        //     Vector3 start = startPoint + Vector3.right * x * cellSize + Vector3.up * yOffset;
        //     Vector3 end = start + Vector3.forward * gridSize * cellSize;
        //     Gizmos.DrawLine(start, end);
        // }
        //
        // for (int y = -gridSize / 2; y <= gridSize / 2; y++)
        // {
        //     Vector3 start = startPoint + Vector3.forward * y * cellSize + Vector3.up * yOffset;
        //     Vector3 end = start + Vector3.right * gridSize * cellSize;
        //     Gizmos.DrawLine(start, end);
        // }
        //
        // // Draw coordinate numbers
        // for (int x = -gridSize / 2; x <= gridSize / 2; x++)
        // {
        //     for (int y = -gridSize / 2; y <= gridSize / 2; y++)
        //     {
        //         Vector3 pos = startPoint + Vector3.right * x * cellSize + Vector3.forward * y * cellSize + Vector3.up * yOffset;
        //         Handles.Label(pos, x.ToString() + "," + y.ToString());
        //     }
        // }
    }
}