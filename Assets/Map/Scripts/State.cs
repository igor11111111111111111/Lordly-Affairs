using Leopotam.Ecs;
using Map;
using UnityEngine;

namespace StateMachine
{
    public abstract class State
    { 
        protected EcsWorld _ecsWorld;
        protected EcsEntity _entity;
        protected StaticData _staticData;
        protected int _time;
        protected int _delay; // 60 = one seconds;

        public void Init(EcsWorld ecsWorld, EcsEntity entity, StaticData staticData)
        {
            _entity = entity;
            _ecsWorld = ecsWorld;
            _staticData = staticData;
        }

        public virtual void Enter()
        {
            _time = -1;
            _delay = 60;
        }

        public virtual void Update()
        {

        }

        public void TimedUpdate()
        {
            _time++;
            if (_time % _delay == 0)
            {
                CustomUpdate();
            }
        }

        public virtual void CustomUpdate()
        {

        }

        public virtual void Exit()
        {

        }
    }
}

