using ECSTemplates;
using Leopotam.Ecs;
using System.Linq;
using UnityEngine;

namespace Map
{
    public enum FindInfo
    {
        MyFactionDomain,
        MyDomain,
        EnemyVillage
    }
      
    public class LordFindTargetSystem : IEcsRunSystem
    {
        private EcsFilter<SquadComponent, FindTargetState, LordTag> _filter = null;
        private EcsWorld _ecsWorld;

        public void Run()
        {
            foreach (var i in _filter)
            {
                //Debug.Log("find");
                ref var squadComponent = ref _filter.Get1(i);
                ref var entity = ref _filter.GetEntity(i);

                entity.Del<FindTargetState>();
                if (squadComponent.Gold >= squadComponent.GoldTreshold &&
                    squadComponent.UnitsDictionary.Count() < squadComponent.PatrolUnitTreshold)
                {
                    var target = GetBuilding(squadComponent, FindInfo.MyFactionDomain);
                    squadComponent.Target = new BuildingTarget(target.Transform.position);
                    entity.Get<RecrutingState>();
                }
                else
                {
                    if (squadComponent.Honor >= 0 && 
                        squadComponent.UnitsDictionary.Count() >= squadComponent.PatrolUnitTreshold)
                    {
                        var target = GetBuilding(squadComponent, FindInfo.MyDomain);
                        squadComponent.Target = new BuildingTarget(target.Transform.position);
                        entity.Get<PatrolState>();
                    }
                    else
                    {
                        GetBuilding(squadComponent, FindInfo.EnemyVillage);
                        entity.Get<PlunderVillageState>();
                    }
                }
            }
        }

        private BuildingComponent GetBuilding(SquadComponent squadComponent, FindInfo findInfo)
        {
            var transform = squadComponent.Transform;
            var radiusVision = squadComponent.RadiusVision;

            EcsEntity[] allEntity = null;
            _ecsWorld.GetAllEntities(ref allEntity);

            var allBuildings = allEntity
                .Where(e => e.Has<BuildingComponent>())
                .ToList()//!?
                .Select(e => e.Get<BuildingComponent>())
                .ToList();
            BuildingComponent buildingComponent = new BuildingComponent();

            if(findInfo == FindInfo.MyFactionDomain)
            {
                buildingComponent = allBuildings
                    .Where(b => b.Faction == squadComponent.Faction)
                    //.OrderBy(bc => Mathf.Abs(Vector3.Magnitude(bc.Transform.position - transform.position)))
                    .FirstOrDefault();
            }
            else if (findInfo == FindInfo.MyDomain)
            {
                var rand = new System.Random();
                buildingComponent = squadComponent.MyDomain
                    [rand.Next(squadComponent.MyDomain.Count)];
            }
            else if (findInfo == FindInfo.EnemyVillage)
            {
                buildingComponent = allBuildings
                    .Where(b =>
                        b.Type == BuildingType.Village &&
                        b.Faction != squadComponent.Faction)
                    .OrderBy(bc => NearDist(bc.Transform, transform))
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

