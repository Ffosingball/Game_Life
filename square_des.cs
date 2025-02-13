using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class square_des : MonoBehaviour
{
    public SpriteRenderer squares;
    public int x_coord=-51, y_coord=-51;
    public uiManager uimanager;

    //main_algorit.width

    // Start is called before the first frame update
    private void OnMouseOver()
    {
        if (uimanager.leftClick)
        {
            main_algorithms.grid[x_coord,y_coord]=0;
            squares.color = Color.white;
        }
        else if(uimanager.rightClick)
        {
            main_algorithms.grid[x_coord,y_coord]=1;
            squares.color = Color.black;
        }
    }

    // Update is called once per frame
    public void changeState(int state)
    {
        squares.color = state==1 ? Color.black : Color.white;
    }
}
