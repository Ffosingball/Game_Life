using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public Button pauseButton;
    public Text pauseText;
    private bool colorChanged;


    private void Start(){
        pauseButton.GetComponent<Image>().color = new Color(0.24f,0.99f,0.36f);
        colorChanged=false;
        pauseText.text="Start";
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
}
