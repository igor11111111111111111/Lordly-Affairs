using ECSTemplates;
using Leopotam.Ecs;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Map
{
    public class OwnerBuildingInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld = null;
        private StaticData _staticData = null;
        private SceneData _sceneData = null;
        //private BuildingComponent aa()
        //{
        //    return e => e.Get<BuildingComponent>();
        //}
        public void Init()
        {

            EcsEntity[] allEntity = null;
            _ecsWorld.GetAllEntities(ref allEntity);

            // 1 player village, 0 aivillage, 2 neutral town
            // 0 player 1 ai lord
            Set(ref allEntity, 1, 0);
            Set(ref allEntity, 0, 1);

            //var buildings2 = allEntity//
            // .Where(e => e.Has<BuildingComponent>())
            // .Select(e => e.Get<BuildingComponent>())
            // .ToList();

            //foreach (var t in buildings2)
            //{
            //    Debug.Log(t.Name);
            //    Debug.Log(t.Owner.Name);
            //}//
        }

        // Set не понятный, т.к при использовании linq не могу прокинуть ref в select фильтрах => делаю через циклы
        private void Set(ref EcsEntity[] allEntity, int squadId, int buildingId)
        {
            foreach (var buildingEntity in allEntity)
            {
                if (!buildingEntity.Has<BuildingComponent>())
                    continue;
                
                ref var buildingComponent = ref buildingEntity.Get<BuildingComponent>();
                if (buildingComponent.Id != buildingId)
                    continue;

                foreach (var squadEntity in allEntity)
                {
                    if (!squadEntity.Has<SquadComponent>())
                        continue;

                    ref var squadComponent = ref squadEntity.Get<SquadComponent>();
                    if (squadComponent.Id != squadId)
                        continue;

                    buildingComponent.Owner = squadComponent;
                    buildingComponent.Faction = squadComponent.Faction;
                    squadComponent.MyDomain.Add(buildingComponent);
                }
            }
        }
    }
}

