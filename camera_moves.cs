using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_moves : MonoBehaviour
{
    public GameObject camera_;
    public float speed=30f;
    /*public float zoomSpeed = 5.0f; // Скорость приближения/удаления
    public float minZoomDistance = 5.0f; // Минимальное расстояние приближения
    public float maxZoomDistance = 100.0f; // Максимальное расстояние удаления*/

    private void awake()
    {
        camera_ = GetComponent<GameObject>();
    }

    // Update is called once per frame
    private void FixedUpdate() 
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(1,0,0)*speed*Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(1,0,0)*-speed*Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0,1,0)*-speed*Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0,1,0)*speed*Time.deltaTime);
        }
    }

    /*private void Update() 
    {
        float scrollDelta = Input.GetAxis("Mouse ScrollWheel"); // Получение значения колесика мыши

        // Изменение позиции камеры на основе значения колесика мыши
        Vector3 newPosition = transform.position + transform.forward * scrollDelta * zoomSpeed;

        // Ограничение расстояния приближения/удаления
        newPosition.y = Mathf.Clamp(newPosition.y, minZoomDistance, maxZoomDistance);

        // Применение новой позиции к камере
        transform.position = newPosition;
    }*/
}
