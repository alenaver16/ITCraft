using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour {
    public void OpenBlacksmith() { SceneManager.LoadScene("Blacksmish"); } // Open Blacksmish scene
    public void OpenDeepspace() { SceneManager.LoadScene("Deepspace"); } // Open Deepspace scene
    public void OpenMenu() { SceneManager.LoadScene("Menu"); } // Open Menu scene
    public void Close() { Application.Quit(); } // Exit
}
