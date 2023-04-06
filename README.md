# DemoMapGenerator
This repository contains a class library and a console application for generating random maps of planets and their interconnecting edges. The class library provides domain models for Map, Planets, and Edges, as well as the logic to generate a random map based on various properties, such as the number of planets and the size of the map.

The Map model represents the overall map and holds a collection of Planet and Edge models. The Planet model represents a planet with its unique ID, name, and coordinates. The Edge model represents an edge connecting two planets and holds the distance between them.

The Planets and Edges models can be used to define custom maps, but the library also includes a MapGenerator class that can generate a random map based on the desired properties. The generator takes input parameters such as the number of planets, the minimum and maximum distances between planets, and the size of the map, and outputs a randomly generated map that satisfies those constraints.

The console application included in the repository uses the class library to generate a map and save it as an image in .png format. The application prompts the user to enter the desired properties for the map, such as the number of planets and the size of the map, and then generates and saves the map as an image file.

Overall, this repository provides a useful tool for generating random maps of planets and their connections, which could be used for various purposes, such as game development or visualization.

## 🧿 Created maps using various algorithms
![image](https://user-images.githubusercontent.com/87979065/230389901-f12f0a72-820b-4a46-96b1-39be36824235.png)
![map](https://user-images.githubusercontent.com/87979065/230390237-c505fb18-77c1-409c-aa25-786609ae722c.png)
![image](https://user-images.githubusercontent.com/87979065/230390279-89ad4e9a-4a91-436b-8b40-470595624819.png)
![image](https://user-images.githubusercontent.com/87979065/230390260-5e8cc1e3-511a-4cc0-a858-13dbc7c2ae1d.png)
