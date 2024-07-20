using UnityEngine;
using UnityEngine.SceneManagement;

namespace Systems
{
    public class SceneController : MonoBehaviour
    {
        public void LoadGame()
        {
            SceneManager.LoadScene(0);
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
