using Leopotam.Ecs;
using UnityEngine;

namespace Map
{
    public class PlayerVision : MonoBehaviour
    { 
        public Collider Collider;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Squad>(out var squad))
            {
                squad.SetActive(true);
                squad.Entity.Get<InPlayerRadiusVision>();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<Squad>(out var squad))
            {
                squad.SetActive(false);
                squad.Entity.Del<InPlayerRadiusVision>();
            }
        }
    }
}
