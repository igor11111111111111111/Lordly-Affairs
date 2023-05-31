using UnityEngine;

namespace Map
{
    public struct CommanderComponent
    {
        public string Name;
        public int MaxHealth;
        public int CurHealth;
        public Mesh Mesh;

        public CommanderComponent(string name, int maxHealth) : this()
        {
            Name = name;
            MaxHealth = maxHealth;
            CurHealth = maxHealth;
        }
    }
}

