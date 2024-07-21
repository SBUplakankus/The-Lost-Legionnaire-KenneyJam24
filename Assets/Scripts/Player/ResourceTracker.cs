using System;
using UI;
using UnityEngine;

namespace Player
{
    public class ResourceTracker : MonoBehaviour
    {
        public static ResourceTracker instance;
        [SerializeField] private BridgeManager bridgeManager;
        public int currentMaterials;
        public int collectiblesFound;
        public int respawns;
        public int[] buildCosts;
        public float timeTaken;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            timeTaken = 0;
            currentMaterials = 0;
            collectiblesFound = 0;
            respawns = 0;
        }

        private void Update()
        {
            timeTaken += Time.deltaTime;
            
        }
        
        public void GetNextBuild()
        {
            if(currentMaterials < buildCosts[bridgeManager.progressIndex]) return;
            currentMaterials -= buildCosts[bridgeManager.progressIndex];
            bridgeManager.BuildBridge();
        }
    }
}
