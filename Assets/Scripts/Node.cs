using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField]
    private Vector2Int index;
    public Vector2Int Index
    {  
        get { return index; }
        set { index = value; }
    }

    [SerializeField]
    private List<Node> neighbours = new List<Node>();
    public List<Node> Neighbours
    {
        get { return neighbours; }
    }

    private int distance;
    public int Distance 
    {
        get { return distance; }
        set { distance = value; }
    }

    private bool available = true;
    public bool Available
    {
        get { return available; }
        set 
        {
            available = value; 
            GetComponent<Renderer>().material.color = Color.gray;
        } 
    }

    public enum Colors
    {
        red,
        green,
        white
    }

    public void SearchNeighbours (GridManager gridManager)
    {
        if (index.x < gridManager.Size.x && index.x < gridManager.Size.y)
        {
            // East
            if (index.x < gridManager.Size.x - 1)
            {
                neighbours.Add(gridManager.Grid[index.x + 1, index.y]);
                // North-East
                if (index.y < gridManager.Size.y -1)
                    neighbours.Add(gridManager.Grid[index.x + 1, index.y + 1]);
                // South-East
                if (index.y > 0)
                    neighbours.Add(gridManager.Grid[index.x + 1, index.y - 1]);
            }
            // West
            if (index.x > 0)
            {
                neighbours.Add(gridManager.Grid[index.x - 1, index.y]);
                // North-West
                if (index.y < gridManager.Size.y -1)
                    neighbours.Add(gridManager.Grid[index.x - 1, index.y + 1]);
                // South-West
                if (index.y > 0)
                    neighbours.Add(gridManager.Grid[index.x - 1, index.y - 1]);
            }
            // North
            if (index.y < gridManager.Size.y - 1)
                neighbours.Add(gridManager.Grid[index.x, index.y + 1]);
            // South
            if (index.y > 0)
                neighbours.Add(gridManager.Grid[index.x, index.y - 1]);
        }
    }

    public void ChangeColorNeighbours (Color _color)
    {
        foreach (Node node in neighbours)
            node.GetComponent<Renderer>().material.color = _color;
        
    }
}
