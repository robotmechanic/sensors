using UnityEngine;

/// <summary>
/// Humidity device.
/// </summary>
public class HumidityDevice : IDevice
{
	public void Measure(Node node)
	{
		Debug.Log("Current Humidity Reading@" + node.x + "," + node.y + " is: " + node.Humidity + "%");
	}

	public void PerformAction(Robot robot)
	{

	}
}