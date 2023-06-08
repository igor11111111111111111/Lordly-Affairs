using ECSTemplates;
using UnityEngine;

namespace Map
{
    public class GroundTarget : ITarget
    {
        public Vector3 Position { get; set; }

        public GroundTarget(Vector3 pos)
        {
            Position = pos;
        }
    }
} 

