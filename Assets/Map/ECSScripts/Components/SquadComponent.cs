using ECSTemplates;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Map
{
    public struct SquadComponent 
    {
        public CommanderComponent Commander;
        public string Name;
        public Squad MonoBeh;
        public Animator Animator;
        public NavMeshAgent NavMeshAgent;
        public int Id;
        public Transform Transform;
        public float Speed; 
        public float Morale;
        public int Gold;
        public int GoldTreshold; // подушка безопасности от которой отталкивается ИИ
        public int PatrolUnitTreshold;
        public ITarget Target;
        public Faction Faction;
        public SocialStatus SocialStatus;
        public float RadiusVision;
        public int Honor;
        public List<BuildingComponent> MyDomain;
        public UnitsDictionary UnitsDictionary;
        public UnitsDictionary PrisonersDictionary;
        public UnitTag UnitTag;
        public Vector3 StartPosition;
        public int MaxSquadSize;
        public int MaxPrisonersSize;

        public SquadComponent(UnitTag unitTag, string name, int gold, int honor, Faction faction, SocialStatus socialStatus, Vector3 startPosition, int radiusVision, UnitsDictionary unitsDictionary, int id) : this()
        {  
            Name = name;
            Gold = gold;
            Faction = faction;
            SocialStatus = socialStatus;
            Honor = honor;
            UnitsDictionary = unitsDictionary;
            PrisonersDictionary = new UnitsDictionary();
            UnitTag = unitTag;
            StartPosition = startPosition;
            RadiusVision = radiusVision;
            GoldTreshold = 1000;
            MaxSquadSize = 20;
            MaxPrisonersSize = 5;
            PatrolUnitTreshold = 15;
            Id = id;
        }
    }
} 

