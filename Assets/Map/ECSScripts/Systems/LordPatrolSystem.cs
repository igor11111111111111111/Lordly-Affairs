using ECSTemplates;
using Leopotam.Ecs;
using UnityEngine;

namespace Map
{ 
    public class LordPatrolSystem : IEcsRunSystem
    {
        private EcsFilter<SquadComponent, PatrolState, LordTag> _filter = null;
          
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var squadComponent = ref _filter.Get1(i);
                ref var entity = ref _filter.GetEntity(i);

                if (squadComponent.Target != null &&
                   squadComponent.Target is BuildingTarget)
                {
                    entity.Get<PatrolInfoComponent>().Target = squadComponent.Target;
                    squadComponent.Target = new GroundTarget(squadComponent.Target.Position
                        + new Vector3(5, 0, 0));
                    entity.Get<FoundTargetEvent>();
                }
                
                if (squadComponent.Target == null)
                {
                    var random = new System.Random();
                    squadComponent.Target = new GroundTarget(
                        entity.Get<PatrolInfoComponent>().Target.Position + 
                        new Vector3(random.Next(-5, 5), 0, random.Next(-5, 5)));
                    entity.Get<FoundTargetEvent>();
                }
            }
        }
    }
}

