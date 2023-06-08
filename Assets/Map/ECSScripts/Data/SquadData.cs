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
        [HideInInspector] public List<SocialStatusClothDictionary> SocialStatusClothDictionary;
        [HideInInspector] public List<SquadComponent> All;

        public void Init()
        {
            SocialStatusClothDictionary = new List<SocialStatusClothDictionary>()
            {
                new SocialStatusClothDictionary(SocialStatus.Player,
                new List<ICloth>()
                {
                    new Torso(27),
                    new ArmUpper(0),
                    new ArmLower(9),
                    new Hand(17),
                    new Hips(3),
                    new Leg(8),
                    new Hair(25)
                }),
                new SocialStatusClothDictionary(SocialStatus.Peasant, 
                new List<ICloth>()
                {
                    new Torso(11),
                    new ArmUpper(11),
                    new ArmLower(0),
                    new Hand(7),
                    new Hips(2), 
                    new Leg(11), 
                    new HeadCoveringsNoHair(10)
                }),
                new SocialStatusClothDictionary(SocialStatus.Lord,
                new List<ICloth>()
                {
                    new Torso(23),
                    new ArmUpper(9),
                    new ArmLower(8),
                    new Hand(14),
                    new Hips(16),
                    new Leg(15),
                    new HeadNoElements(12)
                })
            };

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
            var player = new SquadComponent(new PlayerTag(), "KorvoSquad", 1000, 0, Faction.Player, SocialStatus.Player, new Vector3(1519, 1.12f, -224), 10, units, GetNewID());
            player.PrisonersDictionary = prisoners;
            player.Commander = new CommanderComponent("Korvo", 30);

            return player;
        }

        private SquadComponent DumpyLord()
        {
            var units = new UnitsDictionary();
            for (int i = 0; i < 14; i++)
            {
                units.Add(new Peasant());
            }
            
            var lord = new SquadComponent(new LordTag(), "LordDumpySquad", 1000, 0, Faction.Battania, SocialStatus.Lord, new Vector3(1516, 1.12f, -224), 20, units, GetNewID());

            var commander = new CommanderComponent("Dumpy", 30);
            commander.AllCloth = new List<ICloth>()
            {
                new Torso(23),
                new ArmUpper(9),
                new ArmLower(8),
                new Hand(14),
                new Hips(16),
                new Leg(15),
                new HeadNoElements(12)
            };
            lord.Commander = commander;

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

        public List<ICloth> GetClothBySocialStatus(SocialStatus socialStatus)
        {
            try
            {
                var cloth = SocialStatusClothDictionary.Where(x => x.SocialStatus == socialStatus).FirstOrDefault().Cloth;
                if (cloth == null) { } // dont remove this
                return cloth;
            }
            catch (System.Exception)
            {
                throw new System.Exception("cant find SquadType or Mesh. Add element in SquadData -> Meshs -> SquadType and Mesh");
            }
        }
    }
}

