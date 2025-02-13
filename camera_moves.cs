using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_moves : MonoBehaviour
{
    public Camera camera_;
    public GameObject camera;
    public float speed=30f, zoomSpeed=2, minZoom=10, maxZoom=200;
    /*public float zoomSpeed = 5.0f; // Скорость приближения/удаления
    public float minZoomDistance = 5.0f; // Минимальное расстояние приближения
    public float maxZoomDistance = 100.0f; // Максимальное расстояние удаления*/

    private void awake()
    {
        camera = GetComponent<GameObject>();
    }

    private void Update() 
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(1f,0,0)*speed*Time.deltaTime*(camera_.orthographicSize/10));
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(1f,0,0)*-speed*Time.deltaTime*(camera_.orthographicSize/10));
            //Debug.Log(speed*Time.deltaTime*(movementDivider/(camera_.orthographicSize/100)));
        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0,1f,0)*-speed*Time.deltaTime*(camera_.orthographicSize/10));
        }

        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0,1f,0)*speed*Time.deltaTime*(camera_.orthographicSize/10));
        }


        if (Input.mouseScrollDelta.y != 0)
        {
            camera_.orthographicSize -= Input.mouseScrollDelta.y * zoomSpeed * 10f;
            camera_.orthographicSize = Mathf.Clamp(GetComponent<Camera>().orthographicSize, minZoom, maxZoom);
            //Debug.Log(currentOrthographicSize);
        }
    }
}
