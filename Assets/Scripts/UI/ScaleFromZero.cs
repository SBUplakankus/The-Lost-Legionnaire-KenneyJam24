using System;
using UnityEngine;

namespace UI
{
    public class ScaleFromZero : MonoBehaviour
    {
        [SerializeField] private GameObject canvas;
        private void OnEnable()
        {
            canvas.transform.localScale = Vector3.zero;
            LeanTween.scale(canvas, Vector3.one, 0.4f).setEase(LeanTweenType.easeOutBack);

        }
    }
}
