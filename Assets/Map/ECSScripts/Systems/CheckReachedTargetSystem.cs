using ECSTemplates;
using Leopotam.Ecs;
using UnityEngine;

namespace Map
{ 
    public class CheckReachedTargetSystem : IEcsRunSystem
    {
        private EcsFilter<SquadComponent, CheckReachedTargetState> _filter = null;
         
        public void Run() 
        {
             
            foreach (var i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);

                ref var squadComponent = ref _filter.Get1(i);
                ref var navMeshAgent = ref squadComponent.NavMeshAgent;
                ref var animator = ref squadComponent.Animator;
                ref var transform = ref squadComponent.Transform;
                ref var target = ref squadComponent.Target;

                if (target != null &&
                    transform.position.x == target.Position.x &&
                    transform.position.z == target.Position.z)
                {
                    entity.Del<CheckReachedTargetState>();
                    entity.Get<ReachedTargetEvent>();
                }
            }
        }
    }
}

