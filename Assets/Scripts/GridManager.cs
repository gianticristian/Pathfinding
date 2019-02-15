using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private GameObject nodePrefab;
    
    [SerializeField]
    private Vector2Int size;
    public Vector2Int Size 
    {
        get { return size; }
    }
    
    [SerializeField]
    private float space;

    private List<Node> grid;
    public List<Node> Grid 
    {
        get { return grid; }
    }

    void Awake ()
    {
        grid = new List<Node>();
        space = nodePrefab.GetComponent<Renderer>().bounds.size.x * (1 + 0.2f);

        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                GameObject node = Instantiate(nodePrefab, Vector3.zero, Quaternion.identity);
                
                node.transform.position = new Vector3(x * space, 0, y * space);
                node.transform.parent = transform;
                node.GetComponent<Node>().Index = new Vector2Int(x, y);
    
                grid.Add(node.GetComponent<Node>());

                
            }
        }

        foreach (Node node in grid)
           node.SearchNeighbours(this);

    }
}
