using UnityEngine;

/// <summary>
/// Wall device.
/// </summary>
public class WallDevice : IDevice
{
	private Node _node;

	public void Measure(Node node)
	{
		_node = node;
		Debug.Log("Wall detected@" + node.x + "," + node.y);
	}

	public void PerformAction(Robot robot)
	{
		if (!_node.isWall)
		{
			robot.Move(new Vector2(_node.x, _node.y));
		};
	}

}