using UnityEngine;

/// <summary>
/// Test class to simulate an environment by creating a grid of Nodes which hold various data
/// </summary>
public class Environment {

    public Node[,] Grid = new Node[20,20];
    public GameObject[,] GridObjects = new GameObject[20,20];

	// Constructor
	public Environment () {
        for(int i=0; i < Grid.GetLength(0); i++)
        {
            for(int j=0; j < Grid.GetLength(1); j++)
            {
                var node = new Node(i,j);

                // If it is at the edge, we make it a wall so we can create a border
                if(i == Grid.GetLength(0) - 1 || i == 0 || j == Grid.GetLength(1) - 1 || j == 0)
                {
                    node.isWall = true;
                }

                Grid[i, j] = node;

                Debug.Log("Grid[" + i + "," + j + "] = " + node.Temperature);
                Debug.Log("Grid[" + i + "," + j + "] = " + node.Humidity);
                Debug.Log("Grid[" + i + "," + j + "] = " + node.Brightness);
                Debug.Log("Grid[" + i + "," + j + "] = " + node.Radiation);
            }
        }

		CreateWalls ();
		CreateFire ();
	}

	/// <summary>
	/// Creates the walls graphic
	/// </summary>
	private void CreateWalls()
    {
        for (int i = 0; i < Grid.GetLength(0); i++)
        {
            for (int j = 0; j < Grid.GetLength(1); j++)
            {
                if (Grid[i, j].isWall)
                {
                    var wall = GameObject.Instantiate(Resources.Load("Wall")) as GameObject;
                    wall.transform.position = new Vector3(i, 0, j);
                    GridObjects[i, j] = wall;
                }
            }
        }
    }

	/// <summary>
	/// Creates a fire graphic if the temperate is too high
	/// </summary>
	private void CreateFire()
    {
        for (int i = 0; i < Grid.GetLength(0); i++)
        {
            for (int j = 0; j < Grid.GetLength(1); j++)
            {
                if (Grid[i, j].Temperature > 450)
                {
                    var fire = GameObject.Instantiate(Resources.Load("Fire")) as GameObject;
                    fire.transform.position = new Vector3(i, -0.5f, j);
                    GridObjects[i, j] = fire;
                }
            }
        }
    }
}

/// <summary>
/// Simple node holding to sensor data
/// </summary>
public class Node
{
    public float x { get; private set; }
    public float y { get; private set; }
    public bool isWall { get; set; }
    public float Temperature { get; private set; }
    public float Humidity { get; private set; }
    public float Brightness { get; private set; }
    public float Radiation { get; private set; }

    /// <summary>
    /// Constructor that generates random values
    /// </summary>
    public Node(float posX, float posY)
    {
        x = posX;
        y = posY;
        isWall = Random.Range(0, 100) > 80 ? true : false;
        Temperature = Random.Range(0, 500);
        Humidity = Random.Range(0, 100);
        Brightness = Random.Range(0, 100);
        Radiation = Random.Range(0, 100);
    }
}