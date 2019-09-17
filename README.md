# HHAB

## Intruction
The world has been infected by a virus, that could spread and has created an enormous zombie apocalypse. The main character, **H2AB**, is hiding in a dark wood, with no equipment to fight back. How long can he survive? Only god knows.

![Poster](https://github.com/bqhuyy/HHAB/blob/master/Marketing/poster.png?raw=true)

## Difficulties:

1. Our first difficulty was finding an idea to create a game that everyone can play so that we can play with our friends. Therefore, the game must be fun, easy to play and memorable.

2. Because our group had four people, we found struggle to merge conflicts. Sometimes, when one of our members changed parameters in inspector and pushed his source to github, there was no changes recognized by git and others had to change inspector’s parameters by themselves which was time-consuming.

3. There was inconsistency between testing phase and product phase. For example, Hieu used canvas from asset store as a prefab for editor scene which worked fine when testing but a bug existed when building the product.

4. Since this game was an online game that everyone can join to play together, we have to dealt with many problems, such as how to host and join a room, how to generate zombies that any players can see and each player can see each other.

5. Terrain optimization. As regards terrain, we initially built a spectacular terrain which took us days to accomplish. However, due to a great deal of vertices in a scene, the game cannot run smoothly. Luckily, thanks to teacher’s advice, we created a new terrain which used less resources by decreasing number of vertices.

6. Regarding to game player’s perspective, at first we tried to use first person controller (FPS) to make the game more natural. However, after a lot of efforts, we failed to use it. Fortunately, we had a unique idea about using the third person controller to control the game player which allowed us to create a creative light that make the game truly scary.

In conclusion, we believe that some existing resources in asset store were not good as they seemed, even though they were built by unity team.


## Requirement
* Unity version: **2019.2.0f1**
* WebGL

## Information
* [Bùi Quốc Huy](https://github.com/bqhuyy), 1651076 - Team leader: providing ideas and resources for members.
* [Đỗ Thái Bảo](https://github.com/bendoppler), 1651059 - Terrain and map builder.
* [Phạm Việt An](https://github.com/phvietan), 1651042 - Network management for multiplayer and enemy spawn mechanism (and report writer).
* [Hoàng Đình Hiếu](https://github.com/DinhHieuHoang), 1651045 - Scripting for main character and enemies.

Along the project every members also help others when in need, so I would like to emphasize that the roles above are not everything they do for the project.


## Demo
* [WebGL](https://bqhuyy.github.io/HHAB/Project/Build/WebGL/index.html)
* [Windows](https://github.com/bqhuyy/HHAB/tree/master/Project/Build/Windows)

## Resources references

1. Environment
* [Urban night sky](https://assetstore.unity.com/packages/2d/textures-materials/sky/urban-night-sky-134468)
* [Nature starter kit 2](https://assetstore.unity.com/packages/3d/environments/nature-starter-kit-2-52977) 
* [Rain drop effect 2](https://assetstore.unity.com/packages/vfx/shaders/fullscreen-camera-effects/rain-drop-effect-2-59986)

2. Zombie
* [Zombie Animation Pack Free](https://assetstore.unity.com/packages/3d/animations/zombie-animation-pack-free-150219)
* [Modern Zombie Free](https://assetstore.unity.com/packages/3d/characters/humanoids/modern-zombie-free-58134)

3. Player
* [Bodyguards](https://assetstore.unity.com/packages/3d/characters/humanoids/bodyguards-31711)

4. Basic asset
* [Standard Assets](https://assetstore.unity.com/packages/essentials/asset-packs/standard-assets-32351)
* [Textmesh pro](https://assetstore.unity.com/packages/essentials/beta-projects/textmesh-pro-84126)
5. Network
* [Network lobby](https://assetstore.unity.com/packages/essentials/network-lobby-41836)

***Note***: This is for **educational purposes** only.