using ECSTemplates;
using Leopotam.Ecs;
using StateMachine;
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
            var playerModel = squad.LeaderModel;
            squad.name = data.Name;
            squad.Init(entity, _sceneData);
            squad.SetActive(false);

            ref var squadComponent = ref entity.Get<SquadComponent>();
            squadComponent = data;
            squadComponent.MonoBeh = squad;
            squadComponent.Animator = playerModel.Animator;
            squadComponent.Transform = squad.transform;
            squadComponent.NavMeshAgent = squad.NavMeshAgent;
            squadComponent.MyDomain = new List<BuildingComponent>();

            playerModel.ClothChanger.Set(_staticData.SquadData.GetClothBySocialStatus(data.SocialStatus), _staticData.AllClothMesh);

            entity.Get<RefreshInfoEvent>();

            Player(ref entity);
            Lord(ref entity);
            Peasant(ref entity);
        }

        private void Player(ref EcsEntity entity)
        {
            ref var squadComponent = ref entity.Get<SquadComponent>();
            if (squadComponent.UnitTag is PlayerTag == false)
                return;

            ref var monoBeh = ref squadComponent.MonoBeh;
            entity.Get<PlayerTag>();
            entity.Get<InPlayerRadiusVision>();
            var vision = Object.Instantiate(_sceneData.PlayerVisionPrefab, monoBeh.transform);
            (vision.Collider as SphereCollider).radius = squadComponent.RadiusVision;
            monoBeh.SetActive(true);
            Object.Destroy(squadComponent.MonoBeh.GetComponent<BoxCollider>());

            ref var stateComponent = ref entity.Get<StateComponent>();
            stateComponent.StateMachine = new StateMachine.StateMachine();
            stateComponent.States = new List<State>();
            stateComponent.States.Add(new PlayerEventsInit(_sceneData));
            stateComponent.States.Add(new IdleState());
            stateComponent.States.Add(new MoveState());
            stateComponent.States.Add(new PlayerRelationshipState());
            foreach (var state in stateComponent.States)
                state.Init(_ecsWorld, entity, _staticData);
            
            stateComponent.ChangeState<IdleState>();
        }

        private void Lord(ref EcsEntity entity)
        {
            ref var squadComponent = ref entity.Get<SquadComponent>();
            if (squadComponent.UnitTag is LordTag == false)
                return;

            entity.Get<LordTag>();
            ref var stateComponent = ref entity.Get<StateComponent>();
            stateComponent.StateMachine = new StateMachine.StateMachine();
            stateComponent.States = new List<State>();
            stateComponent.States.Add(new EntryState());
            stateComponent.States.Add(new MoveState());
            stateComponent.States.Add(new PatrolState());
            stateComponent.States.Add(new RecrutingState());
            foreach (var state in stateComponent.States)
                state.Init(_ecsWorld, entity, _staticData);
            stateComponent.ChangeState<EntryState>();
        }

        private void Peasant(ref EcsEntity entity)
        {
            ref var squadComponent = ref entity.Get<SquadComponent>();
            if (squadComponent.UnitTag is PeasantTag == false)
                return;

            entity.Get<PeasantTag>();
        }
    }
}

