using UnityEngine;

namespace Map
{
    public class TransformMonoBehaviour : MonoBehaviour
    {
        private void Awake()
        {
            TransformTarget.Transform = new GameObject().transform;
        }
    }
} 

