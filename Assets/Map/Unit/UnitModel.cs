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

        public void RefreshCloth(SquadComponent squad, AllClothMesh allClothMesh)
        {
            if (squad.Commander.AllCloth != null)
            {
                ClothChanger.Set(squad.Commander.AllCloth, allClothMesh);
            }
            else
            {
                ClothChanger.Set(squad.UnitsDictionary.GetFirstValue()[0].AllCloth, allClothMesh);
            }

            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
} 
