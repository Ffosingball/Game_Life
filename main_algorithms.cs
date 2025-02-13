using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class main_algorithms : MonoBehaviour
{
    public int width = 201;
    public int height = 201;
    public GameObject Square;
    public static square_des[,] grid_of_square;
    public static int[,] grid;
    private static bool Cont_inue = false;
    public uiManager uimanager;




    private void Awake()
    {
        grid_of_square = new square_des[width, height];
        grid = new int[width, height];

        for (int i = 0; i<width; i++)
        {
            for (int j = 0; j<height; j++)
            {
                Vector3 position = new Vector3(-((width/2)-1)+i,((height/2)-1)-j,91);
                GameObject newObj = Instantiate(Square, position, Quaternion.identity);
                square_des newSquare = newObj.GetComponent<square_des>();
                newSquare.uimanager = uimanager;
                newSquare.x_coord = i;
                newSquare.y_coord = j;
                grid_of_square[i, j] = newSquare;
            }
        }
    }





    static int proverca(int c, int coord, int x, int y) 
        {

            if (coord == 1 && (c == 2 || c == 3))
            {
                coord = 1;
            }
            else if (coord == 1)
            {
                coord = 0;
            }
            else if (coord == 0 && c == 3)
            {
                coord = 1;
            }
            else
            {
                coord = 0;
            }
            
            grid_of_square[x,y].changeState(coord);

            return coord;
        }






    private void NextStep()
    {
        int[,] grid_2 = new int[width, height];

        for (int y = 0; y < height; y++)
        {
            if (y==0)
            {

                for (int x = 0; x < width; x++)
                {
                    if (x == 0)
                    {
                        int c = 0, coord;

                        if (grid[x, y + 1] == 1)
                            c++;
                        if (grid[x + 1, y + 1] == 1)
                            c++;
                        if (grid[x + 1, y] == 1)
                            c++;

                        coord = grid[x, y];
                        grid_2[x, y] = proverca(c, coord, x, y);
                    }
                    else if (x == width-1)
                    {
                        int c = 0, coord;

                        if (grid[x - 1, y + 1] == 1)
                            c++;
                        if (grid[x, y + 1] == 1)
                            c++;
                        if (grid[x - 1, y] == 1)
                            c++;

                        coord = grid[x, y];
                        grid_2[x, y] = proverca(c, coord, x, y);
                    }
                    else
                    {
                        int c = 0, coord;

                        if (grid[x - 1, y + 1] == 1)
                            c++;
                        if (grid[x, y + 1] == 1)
                            c++;
                        if (grid[x + 1, y + 1] == 1)
                            c++;
                        if (grid[x - 1, y] == 1)
                            c++;
                        if (grid[x + 1, y] == 1)
                            c++;

                        coord = grid[x, y];
                        grid_2[x, y] = proverca(c, coord, x, y);
                    }
                }

            }
            else if (y==height-1)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == 0)
                    {
                        int c = 0, coord;

                        if (grid[x, y - 1] == 1)
                            c++;
                        if (grid[x + 1, y - 1] == 1)
                            c++;
                        if (grid[x + 1, y] == 1)
                            c++;

                        coord = grid[x, y];
                        grid_2[x, y] = proverca(c, coord, x, y);
                    }
                    else if (x == width-1)
                    {
                        int c = 0, coord;

                        if (grid[x - 1, y - 1] == 1)
                            c++;
                        if (grid[x, y - 1] == 1)
                            c++;
                        if (grid[x - 1, y] == 1)
                            c++;

                        coord = grid[x, y];
                        grid_2[x, y] = proverca(c, coord, x, y);
                    }
                    else
                    {
                        int c = 0, coord;

                        if (grid[x - 1, y - 1] == 1)
                            c++;
                        if (grid[x, y - 1] == 1)
                            c++;
                        if (grid[x + 1, y - 1] == 1)
                            c++;
                        if (grid[x - 1, y] == 1)
                            c++;
                        if (grid[x + 1, y] == 1)
                            c++;

                        coord = grid[x, y];
                        grid_2[x, y] = proverca(c, coord, x, y);
                    }
                }
            }
            else
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == 0)
                    {
                        int c = 0, coord;

                        if (grid[x, y - 1] == 1)
                            c++;
                        if (grid[x + 1, y - 1] == 1)
                            c++;
                        if (grid[x, y + 1] == 1)
                            c++;
                        if (grid[x + 1, y + 1] == 1)
                            c++;
                        if (grid[x + 1, y] == 1)
                            c++;

                        coord = grid[x, y];
                        grid_2[x, y] = proverca(c, coord, x, y);
                    }
                    else if (x == width-1)
                    {
                        int c = 0, coord;

                        if (grid[x - 1, y - 1] == 1)
                            c++;
                        if (grid[x, y - 1] == 1)
                            c++;
                        if (grid[x - 1, y + 1] == 1)
                            c++;
                        if (grid[x, y + 1] == 1)
                            c++;
                        if (grid[x - 1, y] == 1)
                            c++;

                        coord = grid[x, y];
                        grid_2[x, y] = proverca(c, coord, x, y);
                    }
                    else
                    {
                        int c = 0, coord;

                        if (grid[x - 1, y - 1] == 1)
                            c++;
                        if (grid[x, y - 1] == 1)
                            c++;
                        if (grid[x + 1, y - 1] == 1)
                            c++;
                        if (grid[x - 1, y + 1] == 1)
                            c++;
                        if (grid[x, y + 1] == 1)
                            c++;
                        if (grid[x + 1, y + 1] == 1)
                             c++;
                        if (grid[x - 1, y] == 1)
                            c++;
                        if (grid[x + 1, y] == 1)
                            c++;

                        coord = grid[x, y];
                        grid_2[x,y]=proverca(c, coord, x, y);
                    }
                }
            }
        }

        grid = grid_2;
    }





    private IEnumerator Calculate()
    {
        while(Cont_inue)
        {
            yield return new WaitForSeconds(0.1f);
            NextStep();
        }
    }





    public void click_button()
    {
        if (Cont_inue)
        {
            Cont_inue = false;
        }
        else
        {
            Cont_inue = true;
            StartCoroutine(Calculate());
        }
    }
}
