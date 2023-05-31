using ECSTemplates;
using Leopotam.Ecs;
using System;
using UnityEngine;

namespace Map
{ 
    public class EcsStartup 
    {
        private StaticData _staticData;
        private SceneData _sceneData;

        public EcsWorld EcsWorld => _ecsWorld;
        private EcsWorld _ecsWorld;
        private EcsSystems _updateSystems;
         
        public EcsStartup(StaticData staticData, SceneData sceneData)
        {
            _staticData = staticData;
            _sceneData = sceneData;
        }

        public void Start()
        {
            _ecsWorld = new EcsWorld();
            _updateSystems = new EcsSystems(_ecsWorld);
            RuntimeData runtimeData = new RuntimeData();

            _updateSystems
                .Add(new SquadsInitSystem())
                .Add(new BuildingInitSystem())
                .Add(new OwnerBuildingInitSystem())
                .Add(new CameraControllerSystem())

                .Add(new InputSystem())
                .Add(new SpeedSystem())

                .Add(new LordIdleSystem())
                .Add(new LordFindTargetSystem())
                .Add(new LordPatrolSystem())
                .Add(new LordPlunderVillageSystem())
                .Add(new LordRecrutingSystem())
                .Add(new CheckReachedTargetSystem())
                .Add(new MoveSystem()) // after RecrutSystem
                .Add(new InfoSystem())

                .Inject(_staticData)
                .Inject(_sceneData)
                .Inject(runtimeData)
                .OneFrame<FoundTargetEvent>()
                .OneFrame<ReachedTargetEvent>()
                .OneFrame<RefreshInfoEvent>()
                .OneFrame<MouseEnterEvent>()
                .OneFrame<MouseExitEvent>();

            _updateSystems.Init();

            // Debug
            //EcsEntity[] allEntity = null;
            //_ecsWorld.GetAllEntities(ref allEntity);
            //foreach (var entity in allEntity)
            //{
            //    if (entity.Has<SquadComponent>())
            //    {
            //        Debug.Log("///////");
            //        Debug.Log(entity);
            //        Debug.Log(entity.Get<SquadComponent>().MonoBeh.Entity);
                    
            //    }
            //}
        }

        public void Update()
        {
            _updateSystems?.Run();
        }

        public void OnDestroy()
        {
            _ecsWorld?.Destroy();
            _updateSystems?.Destroy();
        }
    }
}

