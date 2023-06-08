using Leopotam.Ecs;
using Map;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StateMachine
{
    public class StateMachineEcsConnectSystem : IEcsRunSystem
    {
        private EcsFilter<StateComponent>.Exclude<PauseComponent> _filter = null;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var stateComponent = ref _filter.Get1(i);
                stateComponent.StateMachine.CurrentState.Update();
                stateComponent.StateMachine.CurrentState.TimedUpdate();
            }
        }
    }
}

