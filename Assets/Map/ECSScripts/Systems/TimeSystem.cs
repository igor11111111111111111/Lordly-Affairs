using Leopotam.Ecs;
using System;
using UnityEngine;

namespace Map
{
    public class TimeSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter<SquadComponent> _filter = null;
        private EcsFilter<EnterPlayerRelationshipStateComponent> _enterPlayerRelationshipState = null;
        private Action OnClickPause;
        private bool _InPauseBtn;

        public void Init()
        {
            _InPauseBtn = false;
            OnClickPause += ClickPause;
        }

        public void Run()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = Time.timeScale == 0 ? 1 : 0;
                OnClickPause?.Invoke();
                _InPauseBtn = !_InPauseBtn;
            }

            if (_enterPlayerRelationshipState.IsEmpty() && !_InPauseBtn)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }

        private void ClickPause()
        {
            foreach (var i in _filter)
            {
                ref var squadComponent = ref _filter.GetEntity(i);
                if (Time.timeScale == 0)
                    squadComponent.Get<PauseComponent>();
                else
                    squadComponent.Del<PauseComponent>();
            }
        }
    }
}

