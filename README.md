# Triple M - Measure, Make, Manage
###### Unity Version 2022.3.20f1

<br>

## Build
1. Open up Main.unity within Assets/Scenes
2. Save any changes modified
3. Open build settings
4. Ensure that the platform is android and all the settings is as desired
5. Build and run


## Run
1. Setup spacial scan within physical space in the Quest3's settings
2. Open Library
3. Change to Unknown Source from All Application on Top Right Corner
4. Open "Triple M"


## Instructions
- Selecting Objects
    - Pinch (Connecting your thumb and index finger together) using either left or/and right hand
    - Picking up objects using both hands works too

- Scaling Objects
    - Pinch the objects using both hands
    - Move both hands on the opposite direction to make it bigger
    - Move both hands closer to each other to make it smaller

- "Asset" Menu
    - All possible asset's icon will be shown on a horizontal scroll wheel 
    - Spawn button is available
        - Select an asset until it turns on
        - Press the Spawn button until it turns on
        - After a few frames the button will turn off by itself

- "Buttons" Menu
    - Consists of 4 Buttons: 
        - Pin 
        - Annotate
        - Create Ruler
        - Destroy 
    - Buttons will turn:
        - Blue if on
        - Black if off

- Button Actions
    - Pin: Disable physics for the chosen object
        - Hover/Select on an object and press the button to turn on/off
    - Annotate: Displays the description of the object
        - Hover/Select on an object and press sthe button to turn on/off
        - To switch annotation between object either hover/select onto another without necessary action of pressing the button on/off
    - Create Ruler: Creates a ruler for the user to measure
        - Just press the buttons, it will turn on and off after a few frames
    - Destroy: to remove chosen object
        - Hover/Select on an object
        - Destroy button will then appear
        - After pressed the button will disappear alongside the object


## Dependency
- Sketchfab C# Plugin: https://github.com/Zoe-Immersive/SketchfabCSharp?tab=readme-ov-file
- JSONDotNet
- XR Interaction Toolkit: https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@3.0/manual/index.html
- AR Foundations: https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@6.0/manual/index.html
- Universal Rendering Pipeline

