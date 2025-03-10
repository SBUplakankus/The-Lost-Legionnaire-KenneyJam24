using UnityEngine;
using UnityEngine.SceneManagement;

namespace Systems
{
    public class SceneController : MonoBehaviour
    {
        /// <summary>
        /// Load the Main Game Scene
        /// </summary>
        public void LoadGame()
        {
            SceneManager.LoadScene(1);
        }

        public void MainMenu(){
            SceneManager.LoadScene(0);
        }
    }
}
