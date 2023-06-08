using UnityEngine;

namespace Battle
{
    public class CustomAnimator
    {
        private Animator _animator;
        private string _curState;

        public CustomAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void Set(string newState)
        {
            if (_curState == newState) return;
            _animator.Play(newState);
            _curState = newState;
        }
    }
}

