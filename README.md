<iframe src="https://giphy.com/embed/XJnTUe61NGCdC0XHTr" width="480" height="360" frameBorder="0" class="giphy-embed" allowFullScreen></iframe><p><a href="https://giphy.com/gifs/XJnTUe61NGCdC0XHTr">via GIPHY</a></p>

# sensors
Sensors Assignment

The Robot class is a simple implementation of a robot. At first, I thought I would have a robot moving around randomly in a simple environment and sensing the world around it, but then I realized that if there were walls in the environment, it would need a wall sensor. However, if I wanted to keep the ISensor class simple (SRP), I would need another interface to perform actions based on the sensor data. Hence, I created a Device class that inherits both the ISensor and IDevice interfaces. I thought this would be a reasonable way to add more devices without having to change the Robot class every time you needed to add a new device.

In addition to adding a Wall detector device, I thought it might be fun for the robot to do something aside from randomly wander from place to place taking data, so by adding the Temperature device, the robot will put out fires, designated by a red square, when the robot detects a temperature hotter than 450 degrees C. 

The Environment class creates a randomized test environment with randomized attributes such as temperature, humidity, etc. It is instantiated by the Robot class when the Robot is initialized. 

Anyway, I hope I haven’t totally missed the mark on this assignment and at the very least addressed the requirements. 

