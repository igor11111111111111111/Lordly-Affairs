using Map;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PlayerRedactor
{
    public class UnitRotator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private GameObject _dragTextAnimation;
        private PointerEventData _eventData = null;
        private UnitModel _unitModel;

        public void Init(UnitModel unitModel, GameObject dragTextAnimation)
        {
            _unitModel = unitModel;
            _dragTextAnimation = dragTextAnimation;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _eventData = eventData;
            _dragTextAnimation.gameObject.SetActive(false);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _eventData = null;
        }

        private void Update()
        {
            if (_eventData == null) return;
            _unitModel.transform.Rotate(0, -_eventData.delta.x, 0);
        }
    }
}