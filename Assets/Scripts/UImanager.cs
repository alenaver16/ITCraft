using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour {
    public void OpenBlacksmith() { SceneManager.LoadScene("Blacksmish"); }
    public void OpenDeepspace() { SceneManager.LoadScene("Deepspace"); }
    public void OpenMenu() { SceneManager.LoadScene("Menu"); }
    public void Close()
    {
        //GUI.Label(new Rect(50, 10, 180, 30), "Вы уже выходите?");
        //    if (GUI.Button(new Rect(10, 40, 180, 30), "Да"))
        //    {
                Application.Quit();
            //}
            //if (GUI.Button(new Rect(10, 80, 180, 30), "Нет"))
            //{
            //    SceneManager.LoadScene("Menu");
            //}
    }
}
