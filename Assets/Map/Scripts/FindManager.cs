using Leopotam.Ecs;
using Map;
using System.Linq;
using UnityEngine;

namespace StateMachine
{
    public class FindManager
    {
        private SquadComponent _squadComponent;
        private EcsWorld _ecsWorld;

        public FindManager(SquadComponent squadComponent, EcsWorld ecsWorld)
        {
            _squadComponent = squadComponent;
            _ecsWorld = ecsWorld;
        }

        public BuildingComponent GetBuilding(FindInfo findInfo)
        {
            EcsEntity[] allEntity = null;
            _ecsWorld.GetAllEntities(ref allEntity);

            var allBuildings = allEntity
                .Where(e => e.Has<BuildingComponent>())
                .Select(e => e.Get<BuildingComponent>())
                .ToList();
            BuildingComponent buildingComponent = new BuildingComponent();

            if (findInfo == FindInfo.MyFactionDomain)
            {
                buildingComponent = allBuildings
                    .Where(b => b.Faction == _squadComponent.Faction)
                    .FirstOrDefault();
            }
            else if (findInfo == FindInfo.MyDomain)
            {
                var rand = new System.Random();
                buildingComponent = _squadComponent.MyDomain
                    [rand.Next(_squadComponent.MyDomain.Count)];
            }
            else if (findInfo == FindInfo.EnemyVillage)
            {
                buildingComponent = allBuildings
                    .Where(b =>
                        b.Type == BuildingType.Village &&
                        b.Faction != _squadComponent.Faction)
                    .OrderBy(bc => NearDist(bc.Transform, _squadComponent.Transform))
                    .FirstOrDefault();
            }
            return buildingComponent;
        }

        private float NearDist(Transform tr1, Transform tr2)
        {
            return Mathf.Abs(Vector3.Magnitude(tr1.position - tr2.position));
        }
    }
}

