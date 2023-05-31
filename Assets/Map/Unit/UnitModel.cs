using UnityEngine;

namespace Map
{
    public class UnitModel : MonoBehaviour
    {
        [SerializeField] public SkinnedMeshRenderer SkinnedMeshRenderer;
        [SerializeField] public Animator Animator;
        [SerializeField] private GameObject _armature;
        [SerializeField] private GameObject _mesh;

        public void SetActive(bool active)
        {
            _armature.SetActive(active);
            _mesh.SetActive(active);
        }
    }
} 
