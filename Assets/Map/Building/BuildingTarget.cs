using ECSTemplates;
using UnityEngine;

namespace Map
{
    public class BuildingTarget : ITarget
    {
        public Vector3 Position { get => _position; set => _position = value; }
        private Vector3 _position;

        public BuildingTarget(Vector3 position)
        {
            Position = position;
        }
    }
} 

