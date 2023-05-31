using Leopotam.Ecs;
using System.Threading.Tasks;
using UnityEngine;

namespace Map
{
    public class LordRecrutingSystem : IEcsRunSystem
    {
        private EcsFilter<SquadComponent, RecrutingState, LordTag> _filter = null;
        private EcsWorld _ecsWorld;
         
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var squadComponent = ref _filter.Get1(i);
                ref var entity = ref _filter.GetEntity(i);
                if (!entity.Has<MoveState>() && squadComponent.Target != null)
                {
                    entity.Get<MoveState>();
                    entity.Get<FoundTargetEvent>();
                }
                else if (squadComponent.Target == null) // in building
                {
                    ref var time = ref entity.Get<RecrutingInfoComponent>().Time;
                    time++;
                    if (time < RecrutingInfoComponent.TimeCD) continue;
                    time -= RecrutingInfoComponent.TimeCD;

                    HireUnit(new Peasant(), ref squadComponent, ref entity);
                    HireUnit(new Militia(), ref squadComponent, ref entity);

                    if (squadComponent.UnitsDictionary.Count() >= squadComponent.PatrolUnitTreshold)
                    {
                        entity.Del<RecrutingState>();
                        entity.Get<FindTargetState>();
                    }
                }
            }
        }

        private void HireUnit(IUnit unit, ref SquadComponent squadComponent, ref EcsEntity entity)
        {
            squadComponent.UnitsDictionary.Add(unit);
            squadComponent.Gold -= unit.Price;
            entity.Get<RefreshInfoEvent>();
        }
    }
} 