using UnityEngine;
using System;

namespace Map
{
    [Serializable]
    public class BuildingInfo
    {  
        public string Name;
        public int Id => _id;
        private int _id;
        public BuildingType Type;
        public Vector3 Position;

        public BuildingInfo(string name, BuildingType type, Vector3 position, int id)
        {
            Name = name;
            Type = type;
            Position = position;
            _id = id;
        }
    }  
}

