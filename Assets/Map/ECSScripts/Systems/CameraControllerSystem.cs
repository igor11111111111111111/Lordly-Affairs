using Leopotam.Ecs;
using System;
using UnityEngine;

namespace Map
{
    public class CameraControllerSystem : IEcsInitSystem, IEcsRunSystem
    {
        private float _horisontalMoveSpeed = 0.4f;
        private float _horisontalRotateSpeed = 1f;
        private float _verticalRotateSpeed = 1.3f;
        private float _verticalMoveSpeed = 6f;
        private Camera _cameraGO;
        private SceneData _sceneData;
        //private EcsWorld _ecsWorld;
        //private EcsEntity _cameraEntity;
         
        public void Init()
        {
            //_cameraEntity = _ecsWorld.NewEntity();
            //_cameraEntity.Get<CameraTag>();
            _cameraGO = _sceneData.MainCamera;
        }

        public void Run()
        {
            var angleRad = _cameraGO.transform.localEulerAngles * Mathf.Deg2Rad;
            if (Input.GetKey(KeyCode.W))
            {
                NewPos(Mathf.Sin(angleRad.y), 0, Mathf.Cos(angleRad.y));
            }
            if (Input.GetKey(KeyCode.A))
            {
                _cameraGO.transform.position -= _cameraGO.transform.right * _horisontalMoveSpeed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                NewPos(-Mathf.Sin(angleRad.y), 0, -Mathf.Cos(angleRad.y));
            }
            if (Input.GetKey(KeyCode.D))
            {
                _cameraGO.transform.position += _cameraGO.transform.right * _horisontalMoveSpeed;
            }


            if (Input.GetKey(KeyCode.E))
            {
                Rotate(1);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                Rotate(-1);
            }
            
            if (Input.mouseScrollDelta.y < 0 && _cameraGO.transform.eulerAngles.x <= 88.6f)
            {
                NewPos(Mathf.Sin(angleRad.y), _verticalMoveSpeed, Mathf.Cos(angleRad.y));
                _cameraGO.transform.Rotate(new Vector3(_verticalRotateSpeed, 0, 0));
            }
            if (Input.mouseScrollDelta.y > 0 && _cameraGO.transform.eulerAngles.x >= 40)
            {
                NewPos(-Mathf.Sin(angleRad.y), -_verticalMoveSpeed, -Mathf.Cos(angleRad.y));
                _cameraGO.transform.Rotate(new Vector3(-_verticalRotateSpeed, 0, 0));
            }
        }

        private void NewPos(float x, float y, float z)
        {
            Vector3 offset = new Vector3(x, y, z);
            _cameraGO.transform.position = Vector3.Lerp(_cameraGO.transform.position, _cameraGO.transform.position + offset, _horisontalMoveSpeed);
        }

        private void Rotate(int sign)
        {
            Vector3 eulers = new Vector3(0, Mathf.Sign(sign) * _horisontalRotateSpeed, 0);
            _cameraGO.transform.Rotate(eulers, Space.World);
        }
    }
}

