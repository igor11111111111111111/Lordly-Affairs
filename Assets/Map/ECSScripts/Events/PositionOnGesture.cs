using UnityEngine;
using UnityEngine.EventSystems;
using System;

namespace Map
{
    public class PositionOnGesture : MonoBehaviour, IPointerDownHandler
    {
        public Action<Vector3> OnMove;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {  
                var pos = eventData.pointerCurrentRaycast.worldPosition;
                OnMove?.Invoke(pos);
            }
        }
    }
}

