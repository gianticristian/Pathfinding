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


    void Awake ()
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

    void Update ()
    {
        if (Input.GetMouseButtonDown (0)) 
        {    
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
 
            if (Physics.Raycast(ray, out hit, 100)) 
            {
                if(hit.collider.tag == "Node") 
                {                         
                    hit.collider.GetComponent<Node>().ChangeColorNeighbours(Color.black);  
                }
            }    
        }

    }
}
