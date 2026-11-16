# Shot Merger

Shot Merger is a 3D hypercasual runner and shooter game prototype developed in Unity. The player controls a forward-moving firearm steered horizontally via an on-screen joystick, automatically firing projectiles down a track at breakable obstacle barrels. As the weapon advances, it collects modular bullet spawners (+1, +2, +3, x2, x3) that physically attach to the pistol assembly or preceding spawners, dynamically scaling weapon fire rate and firing points. Collisions with barriers and barrels inflict damage or procedurally slice off spawner blocks using real-time cube mesh cutting, with progress tracked toward a finish line and level victory. This repository is a personal prototype and demonstration project, not a maintained product, with last substantial work completed in 2022.

## Gameplay

- **Forward Motion and Steering**: Constant forward movement with horizontal touch/joystick steering handled through Unity physics (`Assets/Scripts/PlayerMovement.cs`).
- **Pistol Firing System**: Automatic projectile instantiation loop based on calculated rate of fire and distributed across active spawner transforms (`Assets/Scripts/PistolController.cs`).
- **Modular Spawner Attachment**: Collision-triggered attachment of spawner units to the player or existing spawner chain with additive or multiplicative fire rate increases (`Assets/Scripts/BulletSpawner.cs`).
- **Projectile Trajectory & Collision**: Forward bullet motion via Rigidbody physics with impact triggers and auto-destruction (`Assets/Scripts/Bullet.cs`).
- **Destructible Health Barrels**: Tracked health displayed via TextMeshPro, triggering explosions and haptic feedback upon depletion (`Assets/Scripts/Barrel.cs`).
- **Procedural Mesh Slicing**: Dynamic division of detached spawner cube meshes into separate physics-enabled rigidbodies on impact (`Assets/Scripts/CubeCut.cs`).
- **Obstacle Collisions**: Impulse forces and modular spawner detachment upon striking track barriers (`Assets/Scripts/Obstacle.cs`).
- **Hit Flash Visual Feedback**: Material emission and color transitions flashing white on bullet contact (`Assets/Scripts/HitFlash.cs`).
- **Target Camera Tracking**: Smooth lerp-based camera following behind player movement (`Assets/Scripts/CameraFollow.cs`).
- **Environmental Object Rotation**: Continuous rotation with optional randomized speed and inverted axes for scene props (`Assets/Scripts/Rotate.cs`).
- **Haptic Vibration Wrapper**: Android vibration integration providing tactile feedback for collisions and game events (`Assets/Scripts/Vibration.cs`).
- **Configurable Spawning System**: Weighted percentage-based object and spawn point distribution system (`Assets/Spawning System/Scripts/SpawningSystem.cs`).
- **Game State & Level Progression**: Level tracking, score UI, win/loss state resolution, and PlayerPrefs persistence (`Assets/Scripts/GameManager.cs`).
- **End-Game Overlay UI**: Results panel presenting victory or defeat screens with restart or progression buttons (`Assets/Scripts/EndGamePanel.cs`).
- **Finish & End Triggers**: Separate trigger volumes for validating course completion and finalizing game state (`Assets/Scripts/FinishLine.cs` and `Assets/Scripts/EndLine.cs`).

## Tech Stack

- **Game Engine**: Unity 2021.3.8f1 (`ProjectSettings/ProjectVersion.txt`)
- **Language**: C# (.NET / Mono)
- **Render Pipeline**: Unity Built-in Render Pipeline
- **Notable Packages** (`Packages/manifest.json`):
  - TextMesh Pro `3.0.6` (`com.unity.textmeshpro`)
  - Unity UI `1.0.0` (`com.unity.ugui`)
  - Visual Scripting `1.7.8` (`com.unity.visualscripting`)
  - Timeline `1.6.4` (`com.unity.timeline`)
  - Test Framework `1.1.31` (`com.unity.test-framework`)

## Project Structure

| Path | Description | Type |
| --- | --- | --- |
| `Assets/Scripts/` | Gameplay mechanics: movement, shooting, spawner merge, barrels, obstacles, camera, and game manager | Own code |
| `Assets/Spawning System/Scripts/` | Standalone weighted probability spawning system script | Own code |
| `Assets/Scenes/` | Scene files: `Gameplay.unity` (main game) and `SpawningSystemTest.unity` (spawner test environment) | Own data / Scenes |
| `Assets/Prefabs/` | Prefabs for the pistol base, modular bullet spawners (+1..+3, x2..x3), barrels, obstacles, and explosion VFX | Own data / Prefabs |
| `Assets/Spawning System/Prefabs/` | Prefabs utilized by the spawning system test scene | Own data / Prefabs |
| `Assets/Spawning System/Materials/` | Color materials used in spawning system prototypes | Own data / Materials |
| `Assets/Materials/` | Materials for the pistol, bullets, spawners, and barrel meshes | Own data / Materials |
| `Assets/Models/` | 3D FBX models for the pistol, barrel, and upgrade cubes | Own data / 3D Models |
| `Assets/Sprites/` | UI sprites and checkerboard texture assets | Own data / Textures |
| `Assets/Packages/Joystick Pack/` | Virtual on-screen joystick asset for mobile touch controls | Third-party asset pack |
| `Assets/Packages/JMO Assets/` | Cartoon FX Remaster, Cartoon FX (legacy), and Toony Colors effects and shaders | Third-party asset pack |
| `Assets/Packages/FreeButtonSet/` | UI button sprites, textures, and demonstration scene | Third-party asset pack |
| `Assets/Packages/TextMesh Pro/` | TextMesh Pro default asset package resources, fonts, and shaders | Third-party / Unity package |
| `Packages/` | Unity Package Manager manifest declaring package dependencies | Configuration / Data |
| `ProjectSettings/` | Unity editor configuration files (build scene list, tags, physics, quality) | Configuration / Data |

## Running / Building

1. Install **Unity 2021.3.8f1** using Unity Hub.
2. In Unity Hub, select **Open** and choose the repository root folder (`shot-merger`).
3. Allow the Unity Editor to import assets and compile project scripts.
4. In the Project window, navigate to `Assets/Scenes/` and double-click `Gameplay.unity`. This scene is configured as the primary scene in `ProjectSettings/EditorBuildSettings.asset`.
5. Enter Play Mode by clicking the **Play** button in the Unity Editor toolbar.

> Note: The project has been documented through static file and source analysis; it was not executed or verified in runtime during this documentation pass.

## Repository Notes

- **Tests**: While `com.unity.test-framework` is declared in `Packages/manifest.json`, no automated unit or playmode test scripts exist in the repository.
- **CI/CD**: No continuous integration or automated build workflows are configured.
- **Commit History**: The repository history consists of a single initial commit (`4caf7ba final`).
- **Project Type**: Developed as a personal hypercasual game mechanic prototype exploring runner weapon-merging gameplay; not an actively maintained software product.

## Third-Party Assets

| Path | Description | Licence Status |
| --- | --- | --- |
| `Assets/Packages/Joystick Pack` | Mobile virtual joystick controller package | Documentation included (`Documentaion.pdf`); no separate license file present |
| `Assets/Packages/JMO Assets/Cartoon FX Remaster` | Cartoon particle VFX and shaders by Jean Moreno | Includes `Readme Cartoon FX Remaster FREE.txt` and `Demo Assets/Kino Bloom/Kino Bloom License.txt` (MIT License) |
| `Assets/Packages/JMO Assets/Cartoon FX (legacy)` | Legacy Cartoon FX particle effects and helper scripts | No separate license file present |
| `Assets/Packages/JMO Assets/Toony Colors` | Stylized toon shading materials and scripts | Includes `!ToonyColors Readme.txt`; no separate license file present |
| `Assets/Packages/FreeButtonSet` | UI button sprites, textures, fonts, and sample scenes | No license file present in repository |
| `Assets/Packages/TextMesh Pro` | Unity TextMesh Pro essential resources and shaders | Standard Unity package documentation included |
