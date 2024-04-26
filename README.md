# Triple M - Measure, Make, Manage
###### Unity Version 2022.3.20f1

<br>

## Build
1. Open up Main.unity within Assets/Scenes
2. Save any changes modified
3. Open build settings
4. Ensure that the platform is android and all the settings is as desired/default
5. Build and run


## Run
1. Setup spacial scan within physical space in the Quest3's settings
2. Ensure that there is at least one "Table" furniture
    - None: Add furniture and label it as "Table"
    - Yes: Complete the scan setup
3. Open Library
4. Change to Unknown Source from All Application on Top Right Corner
5. Open "Triple M"


## Instructions
- Selecting Objects
    - Pinch using either left or/and right hand
    - Picking up objects using both hands works too

- Scaling Objects
    - Pinch the objects using both hands
    - Move both hands on the opposite direction to make it bigger
    - Move both hands closer to each other to make it smaller

- Menu Buttons
    - Hover/Select the chosen object using your left hand
    - Menu buttons will appear on the right hand side
    - To push the buttons, point your finger and press the buttons
    - The buttons will be higlighted when it is selected
    - Colored buttons after selecting means On, Black means off
    - Addition: Buttons could be seen being pushed down slightly when pressed

- Button Actions
    - Pin: Disable physics for the chosen object
    - Annotate: Displays the description of the object
    - Create Ruler: Creates a ruler for the user to measure
    - Destroy: to remove unecessary ruler/s


## Dependency
- Sketchfab C# Plugin: https://github.com/Zoe-Immersive/SketchfabCSharp?tab=readme-ov-file
- JSONDotNet
- XR Interaction Toolkit: https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@3.0/manual/index.html
- AR Foundations: https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@6.0/manual/index.html
