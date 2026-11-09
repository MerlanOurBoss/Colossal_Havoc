# Colossal Havoc in VR

A VR game built with Unity where you play as a giant wreaking havoc on a tiny world: grab villagers and trees, throw them around, and dodge cannon fire.

▶️ [Watch the gameplay on YouTube](https://www.youtube.com/watch?v=_whcceV37qI)

## Gameplay

- **Villagers** walk along patrol routes. You can grab them and throw them, and they die when they hit the ground. Or bring one up to your mouth and eat it.
- **The environment** is interactive too: you can pick up and throw trees and some other objects in the scene.
- **Cannons** (3 in the level) turn toward the player and open fire when the player is visible and within 100 units. Each cannon has its own projectile speed and firing interval.
- **Lives:** the player has 4, and each projectile that hits your head takes one away.
- **Movement:** teleportation across designated areas of the level.

## Tech stack

| | |
|---|---|
| Engine | Unity **2021.3.16f1** |
| Rendering | Universal Render Pipeline 12.1.8 |
| VR | XR Interaction Toolkit 2.0.4, XR Plugin Management, Oculus XR Plugin, OpenXR |
| Input | Unity Input System |
| Villager AI | NavMesh (`NavMeshAgent`) |
| Hands | `Rigidbody`-based physics hands |

## Getting started

**Requirements**

- Unity Hub and Unity 2021.3.16f1 with the **Android Build Support** module (needed to build for a headset)
- A VR headset: the project is set up for Android builds with the Oculus XR Plugin (Meta Quest line), and OpenXR is enabled for PC

**Opening the project**

```bash
git clone https://github.com/MerlanOurBoss/Colossal_Havoc.git
```

1. In Unity Hub, choose **Open** and select the project folder.
2. Open the scene `Assets/Scenes/SampleScene.unity`.
3. Press **Play** with your headset connected. To test without a headset, the project includes the XR Device Simulator.

**Building for the headset**

1. In **File → Build Settings**, select **Android** and click **Switch Platform**.
2. In **Project Settings → Player → Publishing Settings**, provide your own keystore or disable the custom keystore for a debug build.
3. Enable developer mode on the headset and connect it to your computer.
4. Click **Build And Run**.

Minimum Android API level is 24, target is 30.

## Project structure

```
Assets/
├── Scenes/SampleScene.unity   # main level
├── Scripts/                   # game logic
├── Prefabs/                   # villager, projectile, controllers, effects
├── Model/                     # world, villager and cannon models
├── Materials/, Lighting/      # materials and lighting
├── Sound/                     # sound effects
├── XR/                        # XR settings
└── Custom asstest/            # third-party assets, URP and XR settings
```

### Scripts

| Script | Purpose |
|---|---|
| `Player` | Stores the player's lives and handles projectile hits |
| `Cannon` | Aiming at the player, firing, cannon health and destruction |
| `Missile` | Projectile collisions with the player and the ground, explosion effect, cleanup |
| `EnemyHuman` | Villager patrolling between points via NavMesh |
| `HumanDeath` | Kills a villager on impact with the ground |
| `HumanEating` | Eats a villager on contact with the player's head |
| `HandPhysics` | Makes the physics hands follow the controllers (`Oculus Hands Physics`) |

The logic relies on the `PlayerHead`, `Player`, `GroundEarth` and `Missile` tags, so keep them when moving objects between scenes.

## Not implemented yet

- A game over screen: the game continues after the player runs out of lives.

## Third-party assets

- [UniGLTF](https://github.com/ousttrue/UniGLTF) — licenses are in `Assets/Custom asstest/UniGLTF`
- AllSkyFree — skyboxes, `Assets/Scenes/AllSkyFree`
- Oculus Hands Physics — physics hands, `Assets/Custom asstest/Oculus Hands Physics`
