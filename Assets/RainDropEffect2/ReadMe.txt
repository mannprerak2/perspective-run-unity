- Rain Drop Effect 2 v1.6.1 -
Rain Drop Effect2: Effective, Fast and Flexible Rain Distortion Effect for Unity

-------------------------------------------------------------------
1: Motivation
-------------------------------------------------------------------
- There is a few cases achieves a rain distortion effect in public Unity projects. 
- A realistic, fast and flexible rain drop effect is required for beginners.
- Supporting DirectX9 is required.
- Supporting VR is required.
- Simulations of a pseudo friction 

To attain these features, I implemented the Rain Drop Effect (v2) utilizing Unity Engine.


-------------------------------------------------------------------
2: Introduction
-------------------------------------------------------------------
Some useful distortion effects are included in this Unity project. Before an use, you can check

RainDropEffect2/Demo/Demo*.unity

to confirm how to use.


-------------------------------------------------------------------
3: Game-in-Ready Prefabs
-------------------------------------------------------------------
Some basic and useful prefabs are prepared for you. Please use prefabs in

RainDropEffect2/Prefabs

You can D&D the prefab(s) at your scene. Descriptions of them are as follows.

#### Blood Rain
A splash of blood.

#### Rain*
A normal rain drop effect. Note that it is not optimized for mobiles.

#### MobileRain*
Cheap rain effects optimized for mobiles.

#### Water Splash In
A water splash (dive) effect.

#### Water Splash Out 
A water splash (leap out) effect.

#### Frozen
This is a freeze effect in cold environment.

#### VR_*
VR supported effects.

If an effect is not playable at start, you have to call a method from your script. Like below to be described

[RainCameraController].Refresh (); // If you need
[RainCameraController].Play (); 


-------------------------------------------------------------------
4: RainCameraController.cs
-------------------------------------------------------------------
RainCameraController.cs is a main component you'll use. It requires an orthographic camera, or perspective view in case you use VR mode. 
When you attach RainCameraController.cs for an arbitrary game object, a camera is automatically added.
Please refer properties of RainCameraController to customize.

### On Inspector

#### Render Queue
The Render Queue is an important order for rendering. If you are using GUI assets (such as NGUI) under RainCameraController, you can controll the queue of effects. 3000 is a default value.
#### Alpha
You can adjust whole rain alpha value under the camera.

### Property

// It returns the current draw call RainCameraController.cs issues.
public int CurrentDrawCall {get;}

// Gets the max draw call theRainCameraController.cs issues.
public int MaxDrawCall {get;}

// It's true when rain drop controllers are playing.
public bool IsPlaying {get;}

### Method

// You can call this method when you want to redraw rain.
public void Refresh ()

// Starts the rain increasingly.
public void Play ()

// Stops the rain gradually.
public void Stop () 

// Stops the rain immediately.
public void StopImmidiate ()


-------------------------------------------------------------------
5: Important
-------------------------------------------------------------------
You can optimize performance using low scale rain drop normal map.
Do not forget to adjust the resolutions too. In some case, resolutions on mobile platforms are too high.


-------------------------------------------------------------------
6: Contact
-------------------------------------------------------------------
If you have any question, please feel to cantact us.
globegames.info@gmail.com

-------------------------------------------------------------------
Copyright 2017 Globe Games. All rights reserved.