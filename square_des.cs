using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class square_des : MonoBehaviour
{
    public GameObject squares;
    public int x_coord=-51, y_coord=-51;
    //private int width, height;
    //private GameObject[,] grid_of_square;
    //public main_algorithms main_algorit;
    public Material white_mat;
    public Material black_mat;
    //private Renderer renderer;
    //private static bool NonLive=true;
    //private int g=101;

    private void awake()
    {
        squares = GetComponent<GameObject>();
        //renderer = GetComponent<Renderer>();
    }

    //main_algorit.width

    void Start() 
    {
        for (int i = 0; i<main_algorithms.width; i++)
        {
            for (int j = 0; j < main_algorithms.height; j++)
            {
                if (main_algorithms.grid_of_square[i,j]==squares)
                {
                    x_coord=i;
                    y_coord=j;
                    break;
                }
            }

            if (x_coord!=-51)
            {
                break;
            }
        }
    }

    // Start is called before the first frame update
    private void OnMouseDown()
    {
        if (main_algorithms.grid[x_coord,y_coord]==0)
        {
            main_algorithms.grid[x_coord,y_coord]=1;
            squares.GetComponent<Renderer>().material = black_mat;
        }
        else
        {
            main_algorithms.grid[x_coord,y_coord]=0;
            squares.GetComponent<Renderer>().material = white_mat;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (main_algorithms.IsUpdate)
        {
            squares.GetComponent<Renderer>().material = main_algorithms.grid[x_coord,y_coord]==1 ? black_mat : white_mat;
        }
    }
}
