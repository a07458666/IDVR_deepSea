Underwater Scuba Diver Pro is a fully controllable underwater scuba diving model that can run on land or swim in water.

Before use, Unity Standard Assets and Post Processing must be imported into the project in order to run the demo scenes. 

The Unity Standard Assets can be found in the Asset Store, and the following should be selected on import:
Standard Assets -> Characters -> ThirdPersonCharacter
Standard Assets -> Cross Platform Input
Standard Assets -> Editor
Standard Assets -> Effects -> Image Effects
Standard Assets -> Environment

Post Processing can be imported from the Package Manager (Window -> package manager).

Once both Standard Assets and Post Processing is installed, import the Scuba package from the Asset Store.

To add Scuba Diver Pro to your project, follow these instructions: 
-Import the entire package and then drag in the 'DiverFirstPerson' or any other Prefab into your scene.
-Either add the 'WaterSurface' Prefab into your scene or create a new one.
-If you add a new water model, to make the diver interact with the water, add a collider underneath the water and set its 'IsTrigger' to true.
-Change the Tag of the water with the collider to "Water".

When adding a new Diver prefab with either First or Third Person camera's, you will need to do the following for each camera:
-Drill down to the game object with the Camera Script attached (either 'Third Person Camera' or 'First Person Camera').
-On the Sun Shafts component, assign a directional light that is your scenes sun to the 'Shafts Caster' inspector field. Turn on the Sun Shafts component to add Sun Shafts to the camera.
-Optionally, add a 'Caustic Light' directional light game object to the 'Camera Underwater' script so that when camera goes underwater, it will turn the caustic light on or off.
-Optionally, when under water, the camera will turn it's 'Depth of Field' component on. Currently, the camera will focus on the 'head' of the player, to change this, add the transform into the 'Focus on Transform' field.

Diver keyboard inputs in water:
- 'WASD': Move player
- 'C': Sink
- 'Space': Float up
- 'Shift': Swim slowly
- 'V' : Toggle Camera


Version 1.21 -
Should there be missing script references in the BeachScene, the following can be done to fix them.
The water surface puddle and water surface objects should both have the Water.cs script attached to them (from Unity Standard Assets).
Third Person Diver should have Floater, Third Person Swimmer, Third Person Swimmer Controller, and Dive Off Boat scripts.
Camera Manager should have Camera Manager script.
Third Person Free Look Camera and First Person Camera Mover should both have the Simple Smooth Mouse Look and Follow Target scripts attached.
