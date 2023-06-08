using UnityEngine;

namespace Map
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        public SquadData SquadData;
        public BuildingData BuildingData;
        public AllClothMesh AllClothMesh;
        public DialogUI DialogUI;

        public void Init()
        {
            AllClothMesh = new AllClothMesh();
        }
    }
}
 
