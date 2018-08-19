using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple robot
/// </summary>
public class Robot : MonoBehaviour {

	List<IDevice> _machineList = new List<IDevice>();

    private Environment _environment;

	// Use this for initialization
	void Start () {

        // Create a test environment with data for the sensors to be able to detect
        _environment = new Environment();

        // Add Sensors here
        _machineList.Add(new WallDevice());
        _machineList.Add(new TemperatureDevice());

        // Execute the Action method every 0.1 seconds
        InvokeRepeating("Action", 1, .1f);
    }

    /// <summary>
    /// Performs an action
    /// </summary>
    private void Action()
    {
        // Get a random direction to perform detection
        var randomVector = new Vector2(transform.position.x + Random.Range(-1, 2), transform.position.z + Random.Range(-1, 2));
        var node = Detector(randomVector);
        if (node == null) return;

        foreach (var machine in _machineList)
        {
            machine.Measure(node);
            machine.PerformAction(this);
        }

        GenerateGhostTrail();
    }

	/// <summary>
	/// Move the to the specified position.
	/// </summary>
	/// <param name="position">Position.</param>
    public void Move(Vector2 position)
    {
        transform.position = new Vector3(position.x, transform.position.y, position.y);
    }

    /// <summary>
    /// Destroy environment object at specified position
    /// </summary>
    /// <param name="position">target position</param>
    public void Destroy(Vector2 position)
    {
        Destroy(_environment.GridObjects[(int)position.x, (int)position.y]);
    }

    /// <summary>
    /// Our detector
    /// </summary>
    /// <param name="position">Detection </param>
    /// <returns>A Node at the specified position</returns>
    private Node Detector(Vector2 position)
    {
        if (position.x > 0 &&
            position.y > 0 &&
            position.x < _environment.Grid.GetLength(0) &&
            position.y < _environment.Grid.GetLength(1))
        {
            return _environment.Grid[(int)position.x, (int)position.y];
        }

        return null;
    }

    /// <summary>
    /// Generates a cube to indicate a traversed position (eye candy)
    /// </summary>
    private void GenerateGhostTrail()
    {
        var shadow = Instantiate(Resources.Load("Trail")) as GameObject;
        shadow.transform.position = new Vector3(transform.position.x, -0.5f, transform.position.z) ;
    }
}

