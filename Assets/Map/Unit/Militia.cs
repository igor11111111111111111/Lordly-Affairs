using System.Collections.Generic;

namespace Map
{
    public class Militia : IUnit
    {
        public int Price { get => _price; }
        private const int _price = 20;

        public int Salary { get => _salary;}
        private const int _salary = 3;

        public int Morale { get => _morale; set => _morale = value; }

        private int _morale;

        public List<ICloth> AllCloth => new List<ICloth>()
        {
            new Torso(3),
            new Hair(5)
        };
    }
}

