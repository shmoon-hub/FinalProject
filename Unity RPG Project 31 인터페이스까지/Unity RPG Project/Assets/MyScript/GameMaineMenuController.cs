using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaineMenuController : MonoBehaviour
{
     public void LoadSandBoxScene()
    {
        SceneManager.LoadScene("GameMainMenu");
    }
}
