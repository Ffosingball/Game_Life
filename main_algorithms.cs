using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class main_algorithms : MonoBehaviour
{
    public int width = 201;
    public int height = 201;
    public GameObject Square;
    public Dictionary<(int,int),square_des> gridSquares;
    public Dictionary<(int,int),bool> grid;
    private static bool Cont_inue = false;
    public uiManager uimanager;


    void Awake(){
        gridSquares = new Dictionary<(int,int),square_des>();
        grid = new Dictionary<(int,int),bool>();
    }


    private bool proverca(int c, bool coord, int x, int y) 
    {
        if (coord && (c == 2 || c == 3))
        {
            coord = true;
        }
        else if (coord)
        {
            coord = false;
        }
        else if (!coord && c == 3)
        {
            coord = true;
        }
        else
        {
            coord = false;
        }

        //Debug.Log("c: "+c+"; coord: "+coord+"; x: "+x+"; y: "+y);
        
        if(coord && !gridSquares.ContainsKey((x, y)))
            createACell(x,y, 0);
        else if(!coord && gridSquares.ContainsKey((x, y)))
            gridSquares[(x,y)].destroyItself(1);
        
        return coord;
    }


    public void createACell(int x, int y, int g)
    {
        GameObject newObj = Instantiate(Square, new Vector3Int(x,y,91), Quaternion.identity);
        square_des newSquare = newObj.GetComponent<square_des>();
        newSquare.uimanager = uimanager;
        newSquare.algorithm = this;
        newSquare.x_coord = x;
        newSquare.y_coord = y;
        gridSquares[(x, y)] = newSquare;
        
        if(g==1)
            grid[(x,y)] = true;
    }



    public void NextStep()
    {
        Dictionary<(int,int),bool> grid_2 = new Dictionary<(int,int),bool>();
        Dictionary<(int,int),bool> grid_neighbours = new Dictionary<(int,int),bool>();
        //Debug.Log("Step");

        foreach (var kvp in grid)
        {
            (int x, int y) = kvp.Key;
            //Debug.Log(x+"; "+y);
            if (y<-height/2)
            {
                int c = 0;
                bool coord;

                if (x < -width/2)
                {
                    if (grid.ContainsKey((x, y+1)))
                        c++;
                    else
                        grid_neighbours[(x,y+1)]=false;

                    if (grid.ContainsKey((x+1, y+1)))
                        c++;
                    else
                        grid_neighbours[(x+1,y+1)]=false;

                    if (grid.ContainsKey((x+1, y)))
                        c++;
                    else
                        grid_neighbours[(x+1,y)]=false;
                }
                else if (x > width/2)
                {
                    if (grid.ContainsKey((x-1, y+1)))
                        c++;
                    else
                        grid_neighbours[(x-1,y+1)]=false;

                    if (grid.ContainsKey((x, y+1)))
                        c++;
                    else
                        grid_neighbours[(x,y+1)]=false;

                    if (grid.ContainsKey((x-1, y)))
                        c++;
                    else
                        grid_neighbours[(x-1,y)]=false;
                }
                else
                {
                    if (grid.ContainsKey((x-1, y+1)))
                        c++;
                    else
                        grid_neighbours[(x-1,y+1)]=false;

                    if (grid.ContainsKey((x, y+1)))
                        c++;
                    else
                        grid_neighbours[(x,y+1)]=false;

                    if (grid.ContainsKey((x+1, y+1)))
                        c++;
                    else
                        grid_neighbours[(x+1,y+1)]=false;

                    if (grid.ContainsKey((x-1, y)))
                        c++;
                    else
                        grid_neighbours[(x-1,y)]=false;

                    if (grid.ContainsKey((x+1, y)))
                        c++;
                    else
                        grid_neighbours[(x+1,y)]=false;
                }
                    
                coord = kvp.Value;
                if(proverca(c, coord, x, y))
                    grid_2[(x, y)] = true;

            }
            else if (y>height/2)
            {
                int c = 0;
                bool coord;

                if (x < -width/2)
                {
                    if (grid.ContainsKey((x, y-1)))
                        c++;
                    else
                        grid_neighbours[(x,y-1)]=false;

                    if (grid.ContainsKey((x+1, y-1)))
                        c++;
                    else
                        grid_neighbours[(x+1,y-1)]=false;

                    if (grid.ContainsKey((x+1, y)))
                        c++;
                    else
                        grid_neighbours[(x+1,y)]=false;
                }
                else if (x > width/2)
                {
                    if (grid.ContainsKey((x-1, y-1)))
                        c++;
                    else
                        grid_neighbours[(x-1,y-1)]=false;

                    if (grid.ContainsKey((x, y-1)))
                        c++;
                    else
                        grid_neighbours[(x,y-1)]=false;

                    if (grid.ContainsKey((x-1, y)))
                        c++;
                    else
                        grid_neighbours[(x-1,y)]=false;
                }
                else
                {
                    if (grid.ContainsKey((x-1, y-1)))
                        c++;
                    else
                        grid_neighbours[(x-1,y-1)]=false;

                    if (grid.ContainsKey((x, y-1)))
                        c++;
                    else
                        grid_neighbours[(x,y-1)]=false;

                    if (grid.ContainsKey((x+1, y-1)))
                        c++;
                    else
                        grid_neighbours[(x+1,y-1)]=false;

                    if (grid.ContainsKey((x-1, y)))
                        c++;
                    else
                        grid_neighbours[(x-1,y)]=false;

                    if (grid.ContainsKey((x+1, y)))
                        c++;
                    else
                        grid_neighbours[(x+1,y)]=false;
                }

                coord = kvp.Value;
                if(proverca(c, coord, x, y))
                    grid_2[(x, y)] = true;
            }
            else
            {
                int c = 0;
                bool coord;

                if (x < -width/2)
                {
                    if (grid.ContainsKey((x, y-1)))
                        c++;
                    else
                        grid_neighbours[(x,y-1)]=false;

                    if (grid.ContainsKey((x+1, y-1)))
                        c++;
                    else
                        grid_neighbours[(x+1,y-1)]=false;

                    if (grid.ContainsKey((x, y+1)))
                        c++;
                    else
                        grid_neighbours[(x,y+1)]=false;

                    if (grid.ContainsKey((x+1, y+1)))
                        c++;
                    else
                        grid_neighbours[(x+1,y+1)]=false;

                    if (grid.ContainsKey((x+1, y)))
                        c++;
                    else
                        grid_neighbours[(x+1,y)]=false;
                }
                else if (x > width/2)
                {
                    if (grid.ContainsKey((x-1, y-1)))
                        c++;
                    else
                        grid_neighbours[(x-1,y-1)]=false;

                    if (grid.ContainsKey((x, y-1)))
                        c++;
                    else
                        grid_neighbours[(x,y-1)]=false;

                    if (grid.ContainsKey((x-1, y+1)))
                        c++;
                    else
                        grid_neighbours[(x-1,y+1)]=false;

                    if (grid.ContainsKey((x, y+1)))
                        c++;
                    else
                        grid_neighbours[(x,y+1)]=false;

                    if (grid.ContainsKey((x-1, y)))
                        c++;
                    else
                        grid_neighbours[(x-1,y)]=false;
                }
                else
                {
                    //Debug.Log("Right");
                    if (grid.ContainsKey((x-1, y-1)))
                        c++;
                    else
                        grid_neighbours[(x-1,y-1)]=false;
                    
                    if (grid.ContainsKey((x, y-1)))
                        c++;
                    else
                        grid_neighbours[(x,y-1)]=false;

                    if (grid.ContainsKey((x+1, y-1)))
                        c++;
                    else
                        grid_neighbours[(x+1,y-1)]=false;

                    if (grid.ContainsKey((x-1, y+1)))
                        c++;
                    else
                        grid_neighbours[(x-1,y+1)]=false;

                    if (grid.ContainsKey((x, y+1)))
                        c++;
                    else
                        grid_neighbours[(x,y+1)]=false;

                    if (grid.ContainsKey((x+1, y+1)))
                         c++;
                    else
                        grid_neighbours[(x+1,y+1)]=false;

                    if (grid.ContainsKey((x-1, y)))
                        c++;
                    else
                        grid_neighbours[(x-1,y)]=false;

                    if (grid.ContainsKey((x+1, y)))
                        c++;
                    else
                        grid_neighbours[(x+1,y)]=false;
                }

                //Debug.Log("c: "+c);
                coord = kvp.Value;
                if(proverca(c, coord, x, y))
                    grid_2[(x, y)] = true;
            }
        }


        foreach (var kvp in grid_neighbours)
        {
            (int x, int y) = kvp.Key;
            //Debug.Log(x+"; "+y);
            if (y<-height/2)
            {
                int c = 0;
                bool coord;

                if (x < -width/2)
                {
                    if (grid.ContainsKey((x, y+1)))
                        c++;
                    if (grid.ContainsKey((x+1, y+1)))
                        c++;
                    if (grid.ContainsKey((x+1, y)))
                        c++;
                }
                else if (x > width/2)
                {
                    if (grid.ContainsKey((x-1, y+1)))
                        c++;
                    if (grid.ContainsKey((x, y+1)))
                        c++;
                    if (grid.ContainsKey((x-1, y)))
                        c++;
                }
                else
                {
                    if (grid.ContainsKey((x-1, y+1)))
                        c++;
                    if (grid.ContainsKey((x, y+1)))
                        c++;
                    if (grid.ContainsKey((x+1, y+1)))
                        c++;
                    if (grid.ContainsKey((x-1, y)))
                        c++;
                    if (grid.ContainsKey((x+1, y)))
                        c++;
                }
                    
                coord = kvp.Value;
                if(proverca(c, coord, x, y))
                    grid_2[(x, y)] = true;

            }
            else if (y>height/2)
            {
                int c = 0;
                bool coord;

                if (x < -width/2)
                {
                    if (grid.ContainsKey((x, y-1)))
                        c++;
                    if (grid.ContainsKey((x+1, y-1)))
                        c++;
                    if (grid.ContainsKey((x+1, y)))
                        c++;
                }
                else if (x > width/2)
                {
                    if (grid.ContainsKey((x-1, y-1)))
                        c++;
                    if (grid.ContainsKey((x, y-1)))
                        c++;
                    if (grid.ContainsKey((x-1, y)))
                        c++;
                }
                else
                {
                    if (grid.ContainsKey((x-1, y-1)))
                        c++;
                    if (grid.ContainsKey((x, y-1)))
                        c++;
                    if (grid.ContainsKey((x+1, y-1)))
                        c++;
                    if (grid.ContainsKey((x-1, y)))
                        c++;
                    if (grid.ContainsKey((x+1, y)))
                        c++;
                }

                coord = kvp.Value;
                if(proverca(c, coord, x, y))
                    grid_2[(x, y)] = true;
            }
            else
            {
                int c = 0;
                bool coord;

                if (x < -width/2)
                {
                    if (grid.ContainsKey((x, y-1)))
                        c++;
                    if (grid.ContainsKey((x+1, y-1)))
                        c++;
                    if (grid.ContainsKey((x, y+1)))
                        c++;
                    if (grid.ContainsKey((x+1, y+1)))
                        c++;
                    if (grid.ContainsKey((x+1, y)))
                        c++;
                }
                else if (x > width/2)
                {
                    if (grid.ContainsKey((x-1, y-1)))
                        c++;
                    if (grid.ContainsKey((x, y-1)))
                        c++;
                    if (grid.ContainsKey((x-1, y+1)))
                        c++;
                    if (grid.ContainsKey((x, y+1)))
                        c++;
                    if (grid.ContainsKey((x-1, y)))
                        c++;
                }
                else
                {
                    //Debug.Log("Right");
                    if (grid.ContainsKey((x-1, y-1)))
                        c++;
                    if (grid.ContainsKey((x, y-1)))
                        c++;
                    if (grid.ContainsKey((x+1, y-1)))
                        c++;
                    if (grid.ContainsKey((x-1, y+1)))
                        c++;
                    if (grid.ContainsKey((x, y+1)))
                        c++;
                    if (grid.ContainsKey((x+1, y+1)))
                         c++;
                    if (grid.ContainsKey((x-1, y)))
                        c++;
                    if (grid.ContainsKey((x+1, y)))
                        c++;
                }

                //Debug.Log("c: "+c);
                coord = kvp.Value;
                if(proverca(c, coord, x, y))
                    grid_2[(x, y)] = true;
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
