using UnityEngine;

namespace Map
{
    public class UnitModel : MonoBehaviour
    {
        [SerializeField] public ClothChanger ClothChanger;
        [SerializeField] public Animator Animator;
        [SerializeField] private GameObject _mesh;

        public void SetActive(bool active)
        {
            _mesh.SetActive(active);
        }
    }
} 
