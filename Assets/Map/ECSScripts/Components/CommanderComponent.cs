using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public struct CommanderComponent
    {
        public string Name;
        public int MaxHealth;
        public int CurHealth;
        public List<ICloth> AllCloth;

        public CommanderComponent(string name, int maxHealth)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurHealth = maxHealth;
            AllCloth = new List<ICloth>()
            {
                new Torso(3),
                new Hair(5)
            };
        }
    }
}

