using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private GameObject nodePrefab = null;
    
    [SerializeField]
    private Vector2Int size;
    public Vector2Int Size 
    {
        get { return size; }
    }
    
    [SerializeField]
    private float space;

    private Node[,] grid;
    public Node[,] Grid
    {
        get { return grid; }
    }

    [SerializeField]
    private Node start;
    public Node Start 
    {
        get { return start; }
        set { start = value; }
    }

    [SerializeField]
    private Node end;
    public Node End 
    {
        get { return start; }
        set { end = value; }
    }


    public void CreateGrid ()
    {
        grid = new Node[size.x, size.y];

        space = nodePrefab.GetComponent<Renderer>().bounds.size.x * (1 + 0.2f);

        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                GameObject node = Instantiate(nodePrefab, Vector3.zero, Quaternion.identity) as GameObject;
                
                node.transform.position = new Vector3(x * space, 0, y * space);
                node.transform.parent = transform;
                node.GetComponent<Node>().Index = new Vector2Int(x, y);
    
                grid[x, y] = node.GetComponent<Node>();   
            }
        }

        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                grid[x, y].SearchNeighbours(this);
            }
        }
    }

    public void CalculateDistance ()
    {
        Node selectedNode = grid[start.Index.x, start.Index.y].Neighbours[0];
        selectedNode.Distance = Mathf.Abs(selectedNode.Index.x - end.Index.x) + Mathf.Abs(selectedNode.Index.y - end.Index.y);

        grid[selectedNode.Index.x + 2, selectedNode.Index.y].Available = false;


        while (selectedNode != grid[end.Index.x, end.Index.y])
        {
            foreach(Node node in grid[selectedNode.Index.x, selectedNode.Index.y].Neighbours)
            {
                //if (!node.Available)
                //    continue;

               
                selectedNode.GetComponent<Renderer>().material.color = Color.blue;
                node.Distance = Mathf.Abs(node.Index.x - end.Index.x) + Mathf.Abs(node.Index.y - end.Index.y);
                if (node.Distance <  selectedNode.Distance)
                {
                    //Debug.Log(node.Distance + " _ " + selectedNode.Distance);
                    selectedNode = node;
                    selectedNode.Distance = Mathf.Abs(selectedNode.Index.x - end.Index.x) + Mathf.Abs(selectedNode.Index.y - end.Index.y);
                    
                    if (!node.Available)
                    {
                        foreach (Node n in node.Neighbours)
                            Debug.Log(n.Index);
                    }
                   
                    

                }
            }
            
            
        }

    }

}
