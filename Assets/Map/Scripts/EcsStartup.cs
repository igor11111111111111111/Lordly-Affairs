using ECSTemplates;
using Leopotam.Ecs;
using StateMachine;
using System;
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

                .Add(new SpeedSystem())

                .Add(new PlayerMouseClickTargetSystem())
                .Add(new StateMachineEcsConnectSystem())
                .Add(new InfoSystem())
                .Add(new TimeSystem())

                .Inject(_staticData)
                .Inject(_sceneData)
                .Inject(runtimeData)
                .OneFrame<RefreshInfoEvent>()
                .OneFrame<MouseEnterEvent>()
                .OneFrame<MouseExitEvent>()
                .OneFrame<MouseClickEvent>();
            

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

