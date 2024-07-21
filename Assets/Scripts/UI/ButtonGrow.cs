using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class ButtonGrow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private const float TransitionTime = 0.2f;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.LeanScale(new Vector3(1.04f, 1.04f, 1.04f),TransitionTime);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.LeanScale(Vector3.one,TransitionTime / 2);
        }
    }
}
