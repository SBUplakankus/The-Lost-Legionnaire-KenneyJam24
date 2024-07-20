using UnityEngine;

namespace Player
{
    public class ResourceTracker : MonoBehaviour
    {
        public static ResourceTracker instance;
        public int currentMaterials;
        public int collectiblesFound;
        public float timeTaken;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            timeTaken = 0;
            timeTaken += Time.deltaTime;
            currentMaterials = 0;
            collectiblesFound = 0;
        }
    }
}
