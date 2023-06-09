﻿using ECSTemplates;
using UnityEngine;
using UnityEngine.AI;

namespace Map
{ 
    public struct BuildingComponent : ITarget
    {
        public Building MonoBeh;
        public string Name;
        public int Id;
        public Transform Transform;
        public Vector3 Position { get => Transform.position; set { } }
        public Faction Faction;
        public BuildingType Type;
        public SquadComponent Owner;
        public Vector3 StartPosition;
        public SquadComponent Peasant;

        public BuildingComponent(string name, BuildingType type, Vector3 startPosition, int id) : this()
        {
            Name = name;
            Id = id;
            StartPosition = startPosition;
            Type = type;
        }
    }   
} 
 
