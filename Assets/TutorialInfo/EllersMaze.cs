using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllersMaze : MonoBehaviour
{
    //Maze Options:
    [SerializeField] int yValue = 0;
    [Range(0,100)]
    [SerializeField] int R_WallSpawnPercentage = 0;

    //Maze References:
    [SerializeField] GridSpawner gridSpawner;
    [SerializeField] GameObject wall;

    //Variables:
    private Custom_Grid gridXZ;
    private int max_set_value = 1;

    void Start()
    {
        gridXZ = gridSpawner.grid;

        GenerateEllersMaze();
    }

    private void GenerateEllersMaze()
    {
        //Step (1) + (2):
        List<(int[], int)> first_row = new List<(int[], int)>();

        for (int x = 0; x < gridSpawner.width; x++)
        {
            int[] coords = new int[] {x, 0};

            var cellTup = (coords, max_set_value);
            first_row.Add(cellTup);

            max_set_value += 1;
        }

        WorldText_Row(first_row, Color.white, 0);

        //Main Maze Loop:

        var newRow = JoinRow_VericalWall(first_row);

        WorldText_Row(newRow, Color.red, 1);

        for (int i = 0; i < gridSpawner.height; i++)
        {
            //Step(5), Final Row:

            //Step (3), Vertical Walls & Joining:

            //Step (4), Bottom Walls:

            //Step (5 + 2), Adding New Row:
        }

    }

    private List<(int[], int)> JoinRow_VericalWall(List<(int[], int)> input_row)
    {
        var row_copy = new List<(int[], int)>(input_row);

        var first_cell = row_copy[0];
        var last_cell = row_copy[row_copy.Count - 1];

        PlaceWall_XZ(Vector3.forward, first_cell.Item1[0], first_cell.Item1[1]);

        for (int i = 0; i < row_copy.Count; i++)
        {
            if (i + 1 < row_copy.Count)
            {
                var current_cell = row_copy[i];
                var next_cell = row_copy[i + 1];
                bool join = false;

                if (current_cell.Item2 == next_cell.Item2)
                {
                    //Place Wall:
                    join = false;
                }
                else
                {
                    int rand_num = UnityEngine.Random.Range(0, 101);

                    if (inRange_Inclusive(rand_num, 0, R_WallSpawnPercentage))
                    {
                        join = false;
                    }
                    else
                    {
                        join = true;
                    }
                }

                //Wall:
                if (join == false)
                {
                    var coord = next_cell.Item1;

                    //PlaceWall:
                    PlaceWall_XZ(Vector3.forward, coord[0], coord[1]);
                }

                //Join Cell Sets:
                else
                {
                    var newCellTup = (next_cell.Item1, current_cell.Item2);
                    row_copy[i + 1] = newCellTup;
                }
            }
        }

        PlaceWall_XZ(Vector3.forward, last_cell.Item1[0] + 1, last_cell.Item1[1]);

        return row_copy;
    }

    #region Helper Functions

    private void PlaceWall_XZ(Vector3 dir, int x, int z)
    {
        Vector3 world_position = gridXZ.GetWorldPosition(x, z);

        GameObject.Instantiate(wall, world_position, Quaternion.LookRotation(dir));
    }

    private bool inRange_Inclusive(int num, int minRange, int maxRange)
    {
        if (minRange <= num && num <= maxRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void WorldText_Row(List<(int[], int)> row, Color textColor, int yVal)
    {
        GameObject rowObj = new GameObject();

        foreach (var cell_tup in row)
        {
            int[] coords = cell_tup.Item1;
            int set = cell_tup.Item2;

            //create world text:
            var text = new GameObject();
            var mesh = text.AddComponent<TextMesh>();
            mesh.text = set.ToString();
            mesh.color = textColor;

            //place text obj:
            Vector3 worldPosition = gridXZ.GetWorldPosition(coords[0], coords[1]);
            worldPosition = new Vector3(worldPosition.x + gridXZ.GetCellSize() / 2, yVal, worldPosition.z + gridXZ.GetCellSize() / 2);
            text.transform.position = worldPosition;
            text.transform.parent = rowObj.transform;
        }
    }

    #endregion
}
