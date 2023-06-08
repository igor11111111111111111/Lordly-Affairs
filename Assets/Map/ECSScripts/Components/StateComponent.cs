using StateMachine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StateMachine
{
    public struct StateComponent
    {
        public List<State> States;
        public StateMachine StateMachine;

        public void ChangeState<S>()
        {
            State state = null;
            try
            {
                state = States.First(s => s is S);
            }
            catch (System.Exception)
            {
                Debug.Log("Cant find state => LogicSystem.Init().stateComponent.States.Add(" + typeof(S).Name + ")");
            }

            StateMachine.ChangeState(ref state);
        }
    }
} 

