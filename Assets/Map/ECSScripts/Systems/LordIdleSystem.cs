using ECSTemplates;
using Leopotam.Ecs;
using UnityEngine;

namespace Map
{
    public class LordIdleSystem : IEcsRunSystem 
    { 
        private EcsFilter<SquadComponent, IdleState, LordTag> _filter = null;

        public void Run()
        {
            foreach (var i in _filter)
            {
                //Debug.Log("idle");
                ref var squadComponent = ref _filter.Get1(i);
                ref var entity = ref _filter.GetEntity(i);

                entity.Del<IdleState>();
                if (squadComponent.Gold >= squadComponent.GoldTreshold)
                {
                    entity.Get<FindTargetState>();
                }
                else
                {
                    if (squadComponent.Honor >= 0)
                    {
                        entity.Get<PatrolState>();
                    }
                    else
                    {
                        entity.Get<FindTargetState>();
                    }
                }
            }
        }
    }
}

