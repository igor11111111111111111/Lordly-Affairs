using Map;
using UnityEngine;

namespace Battle
{
    public class SceneInit : MonoBehaviour
    {
        public UnitModel _unitModel;
        public CustomAnimator CustomAnimator;
        private void Awake()
        {
            CustomAnimator = new CustomAnimator(_unitModel.Animator);
        }

        private void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            Vector3 direction =  new Vector3(horizontal, 0, vertical).normalized;
            //if (direction != Vector3.zero)
            //{
            //    _unitModel.Animator.SetBool("IsMove", true);
            //}
            //else
            //{
            //    _unitModel.Animator.SetBool("IsMove", false);
            //}
            _unitModel.Animator.SetFloat("X", horizontal);
            _unitModel.Animator.SetFloat("Y", vertical);

            _unitModel.transform.position = Vector3.Lerp(_unitModel.transform.position, _unitModel.transform.position + direction, 1 * Time.deltaTime);
        }
    }
}

