using ECSTemplates;
using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Map
{
    public class SquadsInitSystem : IEcsInitSystem
    {  
        private EcsWorld _ecsWorld = null;
        private StaticData _staticData = null;
        private SceneData _sceneData = null;

        public void Init()
        {
            _staticData.SquadData.Init();
            foreach (var SquadComponent in _staticData.SquadData.All)
            {
                Create(SquadComponent);
            } 
        }

        public void Create(SquadComponent data)
        {
            EcsEntity entity = _ecsWorld.NewEntity();

            Squad squad = Object.Instantiate(_staticData.SquadData.Prefab, data.StartPosition, Quaternion.identity, _sceneData.UnitsContainer);
            squad.name = data.Name;
            var playerModel = squad.LeaderModel;
            squad.Entity = entity;
            squad.SetActive(false);

            ref var squadComponent = ref entity.Get<SquadComponent>();
            squadComponent = data;
            squadComponent.MonoBeh = squad;
            squadComponent.Animator = playerModel.Animator;
            squadComponent.Transform = squad.transform;
            squadComponent.NavMeshAgent = squad.NavMeshAgent;
            squadComponent.MyDomain = new List<BuildingComponent>();

            playerModel.ClothChanger.Set(_staticData.SquadData.GetClothBySocialStatus(data.SocialStatus), _staticData.AllClothMesh);

            entity.Get<IdleState>();
            entity.Get<RefreshInfoEvent>();

            if (data.UnitTag is PlayerTag) //!!! хуй знает как преобразовать без использования <T>. Потом загуглить
            {
                entity.Get<PlayerTag>();
                entity.Get<InPlayerRadiusVision>();
                var vision = Object.Instantiate(_sceneData.PlayerVisionPrefab, squad.transform);
                (vision.Collider as SphereCollider).radius = data.RadiusVision;
                squad.SetActive(true);
                Object.Destroy(squadComponent.MonoBeh.GetComponent<BoxCollider>());
            }
            else if (data.UnitTag is LordTag)
            {
                entity.Get<LordTag>();
                entity.Get<RecrutingInfoComponent>();
                entity.Get<PatrolInfoComponent>();
            }
            else if (data.UnitTag is PeasantTag)
            {
                entity.Get<PeasantTag>();
            }
            else
            {
                Debug.Log("Заебался");
            }//!!!
        }
    }
}

