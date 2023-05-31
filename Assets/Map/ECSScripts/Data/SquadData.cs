using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using ECSTemplates;
using System;
//
//     This SquadData created for easy (convert / save / load) in save data files
//
namespace Map
{
    [CreateAssetMenu]
    public class SquadData : ScriptableObject
    { 
        public Squad Prefab;
        public List<SocialStatusMeshDictionary> SocialStatusMeshDictionary;
        [HideInInspector] public List<SquadComponent> All;

        public void Init()
        {
            All = new List<SquadComponent>();
            All.Add(Player());
            All.Add(DumpyLord());
            All.Add(Peasant());
            //All.Add(LolyLord());
            // add next lord
        }

        private SquadComponent Player()
        {
            var units = new UnitsDictionary();
            units.Add(new Peasant());
            units.Add(new Peasant());
            units.Add(new Peasant());
            units.Add(new Peasant());
            units.Add(new Peasant());
            units.Add(new Militia());
            var prisoners = new UnitsDictionary();
            prisoners.Add(new Peasant());
            prisoners.Add(new Peasant());
            prisoners.Add(new Militia());
            var player = new SquadComponent(new PlayerTag(), "KorvoSquad", 1000, 0, Faction.Player, SocialStatus.Peasant, new Vector3(1509, 1.12f, -230), 10, units, GetNewID());
            player.PrisonersDictionary = prisoners;
            player.Commander = new CommanderComponent("Korvo", 30);

            return player;
        }

        private SquadComponent DumpyLord()
        {
            var units = new UnitsDictionary();
            for (int i = 0; i < 13; i++)
            {
                units.Add(new Peasant());
            }
            
            var lord = new SquadComponent(new LordTag(), "LordDumpySquad", 1000, 0, Faction.Battania, SocialStatus.Lord, new Vector3(1506, 1.12f, -224), 20, units, GetNewID());
            lord.Commander = new CommanderComponent("Dumpy", 30);

            var prisoners = new UnitsDictionary();
            prisoners.Add(new Peasant());
            prisoners.Add(new Peasant());
            prisoners.Add(new Militia());
            lord.PrisonersDictionary = prisoners;

            return lord;
        }

        private SquadComponent LolyLord()
        {
            var units = new UnitsDictionary();
            units.Add(new Peasant());
            units.Add(new Militia());
            var lord = new SquadComponent(new LordTag(), "LolyLordSquad", 1000, 0, Faction.Player, SocialStatus.Lord, new Vector3(1515, 1.12f, -224), 20, units, GetNewID());
            lord.Commander = new CommanderComponent("Loly", 30);

            return lord;
        }

        private SquadComponent Peasant()
        {
            var units = new UnitsDictionary();
            for (int i = 0; i < 6; i++)
            {
                units.Add(new Peasant());
            }

            var squad = new SquadComponent(new PeasantTag(), "Peasants", 100, 0, Faction.Battania, SocialStatus.Peasant, new Vector3(1515, 1.12f, -224), 20, units, GetNewID());

            return squad;
        }

        private int GetNewID()
        {
            if (All.Count == 0)
                return 0;
            return All.Max(s => s.Id) + 1;
        }

        public Mesh GetMeshBySocialStatus(SocialStatus socialStatus)
        {
            try
            {
                var mesh = SocialStatusMeshDictionary.Where(x => x.SocialStatus == socialStatus).FirstOrDefault().Mesh;
                if (mesh == null) { } // dont remove this
                return mesh;
            }
            catch (System.Exception)
            {
                throw new System.Exception("cant find SquadType or Mesh. Add element in SquadData -> Meshs -> SquadType and Mesh");
            }
        }
    }
}

