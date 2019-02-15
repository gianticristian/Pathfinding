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
    private List<Node> neighbours;
    public List<Node> Neighbours
    {
        get { return neighbours; }
        set { neighbours = value; }
    }

    public void SearchNeighbours (GridManager gridManager)
    {
        for (int y = 0; y < 9; y++)
        {
            for (int x = 0; x < 9; x++)
            {
                if (index.x + x < gridManager.Size.x && index.y + y < gridManager.Size.y)
                {
                    //gridManager.Grid.Find(index.x)
                }
                
                
            }
        }
        
    }

}
