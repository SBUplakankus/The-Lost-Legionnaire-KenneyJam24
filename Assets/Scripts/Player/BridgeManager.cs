
using UnityEngine;

namespace Player
{
    public class BridgeManager : MonoBehaviour
    {
        public static BridgeManager instance;
        public int progressIndex;
        public GameObject[] noBridge;
        public GameObject[] bridges;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            foreach (var bridge in bridges)
            {
                bridge.SetActive(false);
            }

            foreach (var non in noBridge)
            {
                non.SetActive(true);
            }

            progressIndex = 0;
        }
    
        /// <summary>
        /// Build a Bridge at the location
        /// </summary>
        public void BuildBridge()
        {
            noBridge[progressIndex].SetActive(false);
            bridges[progressIndex].SetActive(true);    
            progressIndex++;
        }
    }
}
