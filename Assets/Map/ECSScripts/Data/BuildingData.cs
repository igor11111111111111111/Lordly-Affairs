using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Map
{
    [CreateAssetMenu]
    public class BuildingData : ScriptableObject
    { 
        public Building Prefab;
        public List<BuildingTypeDictionary> BuildingTypeDictionary;
        [HideInInspector]
        public List<BuildingComponent> All;

        public void Init()
        {
            All = new List<BuildingComponent>()
            {// нужна обертка на неповторяющиеся id
                new BuildingComponent("PlayerVillage", BuildingType.Village, new Vector3(1524f, 1.12f, -223), 1),
                new BuildingComponent("LordVillage", BuildingType.Village, new Vector3(1506f, 1.12f, -222), 0),
                new BuildingComponent("NeutralTown", BuildingType.Town, new Vector3(1529f, 1.12f, -240), 2),
            };
        }

        public GameObject GetGameObject(BuildingType buildingType)
        {
            return BuildingTypeDictionary.Where(x => x.BuildingType == buildingType).FirstOrDefault().GameObject;
        }

        public Vector3 GetUIInfoTransform(BuildingType buildingType)
        {
            return BuildingTypeDictionary.Where(x => x.BuildingType == buildingType).FirstOrDefault().UIInfoTransform;
        }
    }
}
  
