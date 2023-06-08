using Leopotam.Ecs;
using Map;

namespace StateMachine
{
    public class PlayerRelationshipState : State
    {
        public override void Enter()
        {
            base.Enter();

            if(_entity.Get<SquadComponent>().SocialStatus == SocialStatus.Player)
            {
                _entity.Get<EnterPlayerRelationshipStateComponent>();
                _staticData.DialogUI.TalkSquad(_entity);
            }
        }
    }
}

