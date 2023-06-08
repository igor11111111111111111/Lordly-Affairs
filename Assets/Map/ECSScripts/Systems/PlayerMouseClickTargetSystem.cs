using Leopotam.Ecs;
using StateMachine;
using UnityEngine;

namespace Map
{

    public class PlayerMouseClickTargetSystem : IEcsRunSystem
    {
        private EcsFilter<MouseClickEvent> targetFilter = null;
        private EcsFilter<PlayerTag> playerFilter = null;

        public void Run()
        { 
            EcsEntity playerEntity = EcsEntity.Null;
            EcsEntity targetEntity = EcsEntity.Null;
            foreach (var i in playerFilter)
                playerEntity = playerFilter.GetEntity(i);
            foreach (var i in targetFilter)
                targetEntity = targetFilter.GetEntity(i);

            if (targetEntity == EcsEntity.Null) return;

            ref var playerSquad = ref playerEntity.Get<SquadComponent>();
            ref var targetSquad = ref targetEntity.Get<SquadComponent>();
            playerSquad.Target = targetSquad;
            playerEntity.Get<StateComponent>().ChangeState<MoveState>();
        }
    }
}

