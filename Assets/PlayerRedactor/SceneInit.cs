using Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerRedactor
{
    public class SceneInit : MonoBehaviour
    {
        [SerializeField] private UnitModel _prefab;
        [SerializeField] private UI _ui;

        void Awake()
        {
            var allClothMesh = new AllClothMesh();
            var unitModel = new PlayerSpawner().Create(_prefab, allClothMesh);
            _ui.Init(unitModel);
        }
    }

    public class PlayerSpawner
    {

        public UnitModel Create(UnitModel _prefab, AllClothMesh allClothMesh)
        {
            var unitModel = Object.Instantiate(_prefab, new Vector3(0.3f, -1.47f, 0.8f), Quaternion.Euler(0, 204.6f, 0));
            //new Vector3(0, -1, 2), Quaternion.Euler(0, 180, 0, 0)
            var cloth = new List<ICloth>()
            {
                new Torso(27),
                new ArmUpper(0),
                new ArmLower(9),
                new Hand(17),
                new Hips(3),
                new Leg(8),
                new Hair(25)
            };

            unitModel.ClothChanger.Set(cloth, allClothMesh);

            return unitModel;
        }
    }
}

