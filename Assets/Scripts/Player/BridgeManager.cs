
using Systems;
using UnityEngine;

namespace Player
{
    public class BridgeManager : MonoBehaviour
    {
        public static BridgeManager instance;
        [SerializeField] private PlayerAnimation playerAnimation;
        public int progressIndex;
        public GameObject[] noBridge;
        public GameObject[] bridges;
        public GameObject[] popUps;
        public ParticleSystem[] buildEffects;

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

        public void GetNextBuild()
        {
            
        }
        /// <summary>
        /// Build a Bridge at the location
        /// </summary>
        public void BuildBridge()
        {
            AudioManager.instance.PlayBuild();
            playerAnimation.Build();
            buildEffects[progressIndex].Play();
            noBridge[progressIndex].SetActive(false);
            bridges[progressIndex].SetActive(true);    
            popUps[progressIndex].SetActive(false);
            progressIndex++;
        }
    }
}
