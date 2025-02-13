using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class square_des : MonoBehaviour
{
    public SpriteRenderer squares;
    public int x_coord=-51, y_coord=-51;
    public uiManager uimanager;
    public main_algorithms algorithm;

    //main_algorit.width

    // Start is called before the first frame update
    private void OnMouseOver()
    {
        if (uimanager.leftClick)
        {
            destroyItself();
        }
    }


    public void destroyItself()
    {
        algorithm.gridSquares.Remove((x_coord, y_coord));
        algorithm.grid.Remove((x_coord, y_coord));
        Destroy(gameObject);
    }


    public void destroyItself(int x)
    {
        algorithm.gridSquares.Remove((x_coord, y_coord));
        Destroy(gameObject);
    }
}
