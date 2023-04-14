# DemoMapGenerator
This repository contains a class library and a console application for generating random maps of planets and their interconnecting edges. The class library provides domain models for Map, Planets, and Edges, as well as the logic to generate a random map based on various properties, such as the number of planets and the size of the map.

The Map model represents the overall map and holds a collection of Planet and Edge models. The Planet model represents a planet with its unique ID, name, and coordinates. The Edge model represents an edge connecting two planets and holds the distance between them.

The Planets and Edges models can be used to define custom maps, but the library also includes a MapGenerator class that can generate a random map based on the desired properties. The generator takes input parameters such as the number of planets, the minimum and maximum distances between planets, and the size of the map, and outputs a randomly generated map that satisfies those constraints.

The console application included in the repository uses the class library to generate a map and save it as an image in .png format. The application prompts the user to enter the desired properties for the map, such as the number of planets and the size of the map, and then generates and saves the map as an image file.

Overall, this repository provides a useful tool for generating random maps of planets and their connections, which could be used for various purposes, such as game development or visualization.

## 🧿 Created maps using various algorithms
![map-3](https://user-images.githubusercontent.com/87979065/232127879-4c0d4310-20b6-4087-961b-7d37278a5872.png)
![map-4](https://user-images.githubusercontent.com/87979065/232127911-93bed701-b303-47aa-8026-47e2b5498edf.png)
![map-5](https://user-images.githubusercontent.com/87979065/232127912-82a1cf89-59e9-4a36-ade7-b0564da35c59.png)
![map-6](https://user-images.githubusercontent.com/87979065/232127913-645c460b-d168-459c-bcda-54618b90cbe6.png)
![map-0](https://user-images.githubusercontent.com/87979065/232127915-52d3b731-32e3-4938-b538-1ef85e529434.png)
![map-1](https://user-images.githubusercontent.com/87979065/232127918-576d1f5b-8736-438b-8568-6d79264a7725.png)
![map-2](https://user-images.githubusercontent.com/87979065/232127920-1f31535c-89f8-4604-b0c2-076ddd8eeafd.png)
