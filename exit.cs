using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Для остановки в режиме редактора
        #else
            Application.Quit(); // Для остановки в сборке игры
        #endif
    }
}
