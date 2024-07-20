using System;
using UnityEngine;

namespace UI
{
    public class LookAtCamera : MonoBehaviour
    {
        public Camera mainCamera;
        public Transform worldCanvas;

        private void Update()
        {
            worldCanvas.rotation = Quaternion.Slerp(worldCanvas.rotation, mainCamera.transform.rotation, 4f * Time.deltaTime);
        }
    }
}
