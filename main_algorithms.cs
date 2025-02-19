using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class main_algorithms : MonoBehaviour
{
    public int width = 201;
    public int height = 201;
    public GameObject Square, border;
    public Dictionary<(int,int),GameObject> grid;
    private static bool Cont_inue = false;
    public uiManager uimanager;
    public float speed=10, maxspeed=100, minspeed=1;
    private int generation=0;
    public Button[] otherButtonsToDisable;
    public Text speedText;


    public int getGeneration(){
        return generation;
    }


    void Awake(){
        grid = new Dictionary<(int,int),GameObject>();

        GameObject b1 = Instantiate(border, new Vector3Int(0,(height/2)+1,91), Quaternion.identity);
        b1.transform.localScale = new Vector3Int(width+2,1,1);
        GameObject b2 = Instantiate(border, new Vector3Int(0,(-height/2)-1,91), Quaternion.identity);
        b2.transform.localScale = new Vector3Int(width+2,1,1);
        GameObject b3 = Instantiate(border, new Vector3Int((width/2)+1,0,91), Quaternion.identity);
        b3.transform.localScale = new Vector3Int(1,height+2,1);
        GameObject b4 = Instantiate(border, new Vector3Int((-width/2)-1,0,91), Quaternion.identity);
        b4.transform.localScale = new Vector3Int(1,height+2,1);
    }


    private GameObject proverca(int c, bool coord, int x, int y) 
    {
        GameObject b = null;

        if (coord && (c == 2 || c == 3))
            coord = true;
        else if (coord)
            coord = false;
        else if (!coord && c == 3)
            coord = true;
        else
            coord = false;

        //Debug.Log("c: "+c+"; coord: "+coord+"; x: "+x+"; y: "+y);
        
        if(coord && grid.ContainsKey((x, y)))
            b = grid[(x,y)];
        if(coord && !grid.ContainsKey((x, y)))
            b = createACell(x,y, 0);
        else if(!coord && grid.ContainsKey((x, y)))
            deleteCell(x,y,0);
        
        return b;
    }


    public GameObject createACell(int x, int y, int g)
    {
        GameObject newObj = Instantiate(Square, new Vector3Int(x,y,91), Quaternion.identity);
        if(g==1)
            grid[(x, y)] = newObj;
        
        return newObj;
    }


    public void deleteCell(int x, int y, int g)
    {
        Destroy(grid[(x,y)]);
        if(g==1)
            grid.Remove((x, y));
    }



    public void NextStep()
    {
        generation++;
        Dictionary<(int,int),GameObject> grid_2 = new Dictionary<(int,int),GameObject>();
        Dictionary<(int,int),GameObject> grid_neighbours = new Dictionary<(int,int),GameObject>();
        //Debug.Log("Step");

        foreach (var kvp in grid)
        {
            (int x, int y) = kvp.Key;
            int c = 0;

            //Debug.Log(x+"; "+y);
            if (!(y<-height/2 || y>height/2 || x < -width/2 || x > width/2))
            {
                if (grid.ContainsKey((x-1, y-1)))
                    c++;
                else
                    grid_neighbours[(x-1,y-1)]=null;
                    
                if (grid.ContainsKey((x, y-1)))
                    c++;
                else
                    grid_neighbours[(x,y-1)]=null;

                if (grid.ContainsKey((x+1, y-1)))
                    c++;
                else
                    grid_neighbours[(x+1,y-1)]=null;

                if (grid.ContainsKey((x-1, y+1)))
                    c++;
                else
                    grid_neighbours[(x-1,y+1)]=null;

                if (grid.ContainsKey((x, y+1)))
                    c++;
                else
                    grid_neighbours[(x,y+1)]=null;

                if (grid.ContainsKey((x+1, y+1)))
                    c++;
                else
                    grid_neighbours[(x+1,y+1)]=null;

                if (grid.ContainsKey((x-1, y)))
                    c++;
                else
                    grid_neighbours[(x-1,y)]=null;

                if (grid.ContainsKey((x+1, y)))
                    c++;
                else
                    grid_neighbours[(x+1,y)]=null;
            }

            GameObject obj = proverca(c, true, x, y);
            if(obj!=null)
                grid_2[(x, y)] = obj;
        }


        foreach (var kvp in grid_neighbours)
        {
            (int x, int y) = kvp.Key;
            int c = 0;
            //Debug.Log("Neighbourgh");

            if (!(y<-height/2 || y>height/2 || x < -width/2 || x > width/2))
            {
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

            GameObject obj = proverca(c, false, x, y);
            if(obj!=null)
                grid_2[(x, y)] = obj;
        }

        grid = grid_2;
    }



    private IEnumerator Calculate()
    {
        while(Cont_inue)
        {
            yield return new WaitForSeconds(1/speed);
            NextStep();
        }
    }



    public void click_button()
    {
        if (Cont_inue)
        {
            Cont_inue = false;
            foreach(Button b in otherButtonsToDisable){
                b.interactable = true;
            }
        }
        else
        {
            Cont_inue = true;

            foreach(Button b in otherButtonsToDisable){
                b.interactable = false;
            }

            StartCoroutine(Calculate());
        }
    }


    public void increaseSpeed(){
        if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            speed+=10;
        else
            speed++;

        if(speed>maxspeed)
            speed=maxspeed;
        
        speedText.text = speed+" generations per second";
    }


    public void decreaseSpeed(){
        if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            speed-=10;
        else
            speed--;
        
        if(speed<minspeed)
            speed=minspeed;
        
        speedText.text = speed+" generations per second";
    }
}
