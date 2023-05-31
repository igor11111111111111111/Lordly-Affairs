using ECSTemplates;
using Leopotam.Ecs;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Map
{
    public class BuildingInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld = null;
        private StaticData _staticData = null;
        private SceneData _sceneData = null;
           
        public void Init() 
        {
            _staticData.BuildingData.Init();

            foreach (var data in _staticData.BuildingData.All)
            {
                EcsEntity entity = _ecsWorld.NewEntity();
                var building = Object.Instantiate(_staticData.BuildingData.Prefab, data.StartPosition, Quaternion.identity, _sceneData.BuildingsContainer);
                building.name = data.Name;
                Object.Instantiate(_staticData.BuildingData.GetGameObject(data.Type), building.transform);

                ref var buildingComponent = ref entity.Get<BuildingComponent>();
                buildingComponent = data;
                buildingComponent.Transform = building.transform;
                buildingComponent.MonoBeh = building;
                buildingComponent.MonoBeh.UIInfo.text = buildingComponent.Name;

                building.UIInfo.transform.localPosition = _staticData.BuildingData.GetUIInfoTransform(data.Type);
            }
        }
    }
}

