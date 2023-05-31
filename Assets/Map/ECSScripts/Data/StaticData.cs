using UnityEngine;

namespace Map
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        public SquadData SquadData;
        public BuildingData BuildingData;
        public UnitData UnitData;

        public void Init()
        {
            UnitData.Init();
        }
    }
}
 
