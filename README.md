# Tri-Realm Odyssey

## Project Overview
This project is a multi-genre Unity simulation consisting of three distinct scenes, managed through a linear scene progression system. The application demonstrates proficiency in C# scripting, Unity physics, camera pathing, and terrain generation.

To optimize the repository size, heavy 3D assets (models, textures, and audio) have been excluded. The repository contains the source code, scene hierarchy, and project settings.

**Full Gameplay Recording:**
https://drive.google.com/drive/folders/1IKxYrO4V1gJ7ghpMIwI4WwCE9hCIFZIW?usp=sharing

## Technical Breakdown

### Scene 1: Cinematic Pathing
A low-poly environment focusing on automated camera control and event sequencing.
* **Mechanism:** Utilizes Cinemachine and Unity Timeline to guide the camera through a pre-defined path using empty GameObjects as waypoints.
* **Logic:** A custom script monitors the timeline state. Upon completion of the camera sequence, a UI button is instantiated to trigger the transition to the next scene.

### Scene 2: Physics-Based Racing
A vehicle simulation set in a closed-circuit racetrack environment.
* **Physics:** Implements WheelColliders and Rigidbody physics to handle acceleration, steering, and friction.
* **Input Handling:** Maps user input to vehicle torque and steering angles.
* **Game Loop:** Includes a lap counting system. Completing the required lap activates the interface to load the final scene.

### Scene 3: Dragon Flight Simulation
A large-scale terrain environment featuring 6-DOF (Six Degrees of Freedom) movement mechanics controlled by the user.
* **Environment:** Procedurally sculpted terrain featuring mountains, water bodies, and complex topography.
* **Flight Controller:** A custom C# script governs the dragon character, allowing for full 3D movement (vertical and horizontal axes) and camera follow smoothing.
* **Cycle Reset:** Completing the exploration loop allows the user to reset the application to Scene 1.

## Controls

**Scene 2 (Car Simulation)**
* **Arrow Keys:** Drive and Steer

**Scene 3 (Dragon Flight)**
* **Arrow Keys:** Move Forward, Backward, Left, and Right
* **Enter:** Fly Up (Ascend)
* **Left Shift:** Fly Down (Descend)

## Installation
1.  Clone this repository to your local machine.
2.  Open Unity Hub and add the cloned folder as a new project.
3.  Open "Scene1" located in the Assets/Scenes folder.
4.  Press Play to run the simulation.

*Note: Due to the exclusion of heavy asset files to maintain a lightweight repository (<100MB), some 3D models may appear as pink placeholders. The scripts and game logic remain fully functional.*

## Author
Chandra Mohan RS
B.Tech - Electronics and Communication Engineering
Sastra Deemed University
chandramohanrs218@gmail.com // 127004196@sastra.ac.in
