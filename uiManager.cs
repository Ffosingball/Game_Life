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


    private void Start(){
        pauseButton.GetComponent<Image>().color = new Color(0.24f,0.99f,0.36f);
        colorChanged=false;
        pauseText.text="Start";
    }


    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsPointerOverUIObject())
        {
            rightClick = true;
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
