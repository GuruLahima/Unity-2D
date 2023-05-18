using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PauseMenu : MonoBehaviour
{


  // Start is called before the first frame update
  void Start()
  {

  }

  public void QuitGame()
  {
    Debug.Log("Should quit the game");
#if UNITY_EDITOR
    // works only in Unity Editor
    EditorApplication.isPlaying = false;
#else
        // works only for builds
        Application.Quit();
#endif
  }

  public void PauseGame()
  {
    // pause physics and animatons that depend on timescale
    Time.timeScale = 0f;
  }

  public void UnpauseGame()
  {
    // unpause game
    Time.timeScale = 1;
  }

  public void ToggleFullscreen(bool isFullscreen)
  {

#if UNITY_EDITOR

        EditorWindow window = EditorWindow.focusedWindow;
        // Assume the game view is focused.
        window.maximized = isFullscreen;
#else
        // Toggle fullscreen
        Screen.fullScreen = isFullscreen;
#endif

   }

    public void PrintInt(int value)
    {
        Debug.Log(value);
    }

}
