using UnityEngine;

/// <summary>
/// Temperature device.
/// </summary>
public class TemperatureDevice : IDevice
{
	private Node _node;

	private const float FIRE_THRESHHOLD_TEMP = 450;

	public void Measure(Node node)
	{
		_node = node;
		Debug.Log("Current Temperature Reading@" + node.x + "," + node.y + " is: " + node.Temperature);
	}

	public void PerformAction(Robot robot)
	{
		if (_node.Temperature > FIRE_THRESHHOLD_TEMP)
		{
			Debug.Log("Fire detected@" + _node.x + "," + _node.y);
			robot.Destroy(new Vector2(_node.x, _node.y));
		}
	}
}