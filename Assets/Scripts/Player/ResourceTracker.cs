using System;
using UnityEngine;

namespace Player
{
    public class ResourceTracker : MonoBehaviour
    {
        public static ResourceTracker instance;
        public int currentMaterials;
        public int collectiblesFound;
        public int respawns;
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
    }
}
