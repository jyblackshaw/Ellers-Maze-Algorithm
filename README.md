# Ellers Maze Algorithm
 
![cleanest gif - spedup](https://github.com/jyblackshaw/Ellers-Maze-Algorithm/assets/68715353/fc4d5484-02a8-4b87-bfda-69407ded9ab9)

# Eller's Maze Algorithm

The Eller's Maze Algorithm is a procedural maze generation method that constructs mazes row by row. It's known for its intricate yet speedy maze generation capabilities and the ability to construct mazes of infinite size in linear time. This approach builds the maze using sets to track connected columns, ensuring perfect mazes each time. This repository contains the Unity implementation of Eller's Maze Algorithm, including a visual demonstration of maze generation.

## Tutorial Series

If you're new to Eller's Maze Algorithm or need assistance with its implementation within Unity, check out the comprehensive 3-part YouTube tutorial series I've created. It will comprehensively explain the algorithm, and then later walk you through the steps of implementing it within Unity.

** [Eller's Maze Algorithm Tutorial Series](https://youtube.com/playlist?list=PLOsqD8iK9BePx9knqt1Svmv40oawNZ1aa&si=NjGcBebdXNFb1YCv):
- [Part 1](https://youtu.be/kD-YUSNffFY?si=NZ5BZbuPEe5FRSOb)
- [Part 2](https://youtu.be/5nWUX2TMJrY?si=wBczLIpnxbPVksV5)
- [Part 3](https://youtu.be/p3l9uLspmwI?si=DP1k7K7_dw1YRVvF)

## Usage

1. Clone or download this Unity project.
2. Open the project in Unity.
3. Attach the EllerMazeGenerator script to a GameObject in your scene.
4. Configure the parameters in the inspector as desired.
5. Run the Unity scene to visualize Eller's Maze Algorithm in action.

## How the Algorithm Works

The `EllersMazeGenerator` class provides the maze generation functionality based on the Eller's Maze Algorithm. It operates by constructing the maze row by row, incorporating various steps to create a complex maze structure.

### Algorithm Steps:

1. **Initialize First Row:**
   - Create the first row of cells and assign sets to each cell.
   - Place walls between cells based on specified spawn percentages.

2. **Join Cells to Unique Sets:**
   - Join any cells not members of a set to their own unique set.

3. **Create Right-Walls (Moving from Left to Right):**
   - Randomly decide to add a wall or not.
   - If the current cell and the cell to the right are members of the same set, always create a wall between them (prevents loops).
   - If a wall is not added, union the sets to which the current cell and the cell to the right are members.

4. **Create Bottom-Walls (Moving from Left to Right):**
   - Randomly decide to add a wall or not. Ensure each set has at least one cell without a bottom-wall (prevents isolations).
   - If a cell is the only member of its set, do not create a bottom-wall.
   - If a cell is the only member of its set without a bottom-wall, do not create a bottom-wall.

5. **Decide to Continue Adding Rows or Complete the Maze:**

   a. If you decide to add another row:
      - Output the current row.
      - Remove all right walls.
      - Remove cells with a bottom-wall from their set.
      - Remove all bottom walls.
      - Continue from Step 2.

   b. If you decide to complete the maze:
      - Add a bottom wall to every cell.
      - Moving from left to right:
         - If the current cell and the cell to the right are members of a different set:
            - Remove the right wall.
            - Union the sets to which the current cell and the cell to the right are members.
      - Output the final row.

[Referenced Paper](http://www.neocomputer.org/projects/eller.html#:~:text=Eller's%20algorithm%20creates%20'perfect'%20mazes,to%20only%20a%20single%20row.)

## Project Structure

The main code is represented by the `EllersMazeGenerator` class, responsible for generating Eller's Maze. The `Custom_Grid` class facilitates grid operations for maze generation.

## Dependencies

- Unity (Version 2021.3.4f1) or Later

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
