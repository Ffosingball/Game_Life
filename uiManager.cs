using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class uiManager : MonoBehaviour
{
    public Button pauseButton;
    public Text pauseText;
    private bool colorChanged;
    public bool rightClick=false, leftClick=false;
    public GameObject Square;
    public main_algorithms algorithm;


    private void Start(){
        pauseButton.GetComponent<Image>().color = new Color(0.24f,0.99f,0.36f);
        colorChanged=false;
        pauseText.text="Start";
    }


    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsPointerOverUIObject())
        {
            rightClick=true;
        }
        else if (Input.GetMouseButtonDown(1) && !IsPointerOverUIObject())
        {
            leftClick = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            rightClick = false;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            leftClick = false;
        }
        else if(rightClick){
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log("mouse: "+mousePos);
            Vector3Int position = new Vector3Int(Mathf.RoundToInt(mousePos.x),Mathf.RoundToInt(mousePos.y),91);
            //Debug.Log("pos: "+position);
            if(!algorithm.gridSquares.ContainsKey((position.x, position.y)))
            {
                algorithm.createACell(position.x,position.y,1);
            }
        }

    }


    public void changeColor(){
        if(colorChanged){
            pauseButton.GetComponent<Image>().color = new Color(0.24f,0.99f,0.36f);
            colorChanged=false;
            pauseText.text="Start";
        }
        else{
            pauseButton.GetComponent<Image>().color = new Color(0.96f,0.39f,0.39f);
            colorChanged=true;
            pauseText.text="Stop";
        }
    }


    public void ExitGame()
    {
        Application.Quit();
    }


    private bool IsPointerOverUIObject()
    {
        // For mouse
        if (EventSystem.current.IsPointerOverGameObject())
            return true;

        return false;
    }
}
