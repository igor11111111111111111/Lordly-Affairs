using ECSTemplates;
using UnityEngine;

namespace Map
{
    public class SquadInfo
    {
        public string Name;
        public int Id => _id;
        private int _id;
        public SocialStatus SocialStatus;
        public Faction Faction;
        public int Gold;
        public int Honor;
        public UnitTag UnitTag;
        public Vector3 Position;
        public SquadInfo(UnitTag unitTag ,string name, SocialStatus socialStatus, Faction faction, int gold, int honor, int id, Vector3 pos)
        {
            Name = name;
            SocialStatus = socialStatus;
            Faction = faction;
            Gold = gold;
            Honor = honor;
            UnitTag = unitTag;
            _id = id;
            Position = pos;
        }
    } 
}