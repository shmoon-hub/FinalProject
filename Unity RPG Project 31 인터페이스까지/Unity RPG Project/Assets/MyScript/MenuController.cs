using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG.UI
{
    public class MenuController : MonoBehaviour
    {
        public void LoadSandBoxScene()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}