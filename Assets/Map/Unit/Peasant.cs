using System.Collections.Generic;

namespace Map
{
    public class Peasant : IUnit
    {
        public int Price { get => _price; }
        private const int _price = 10;

        public int Salary { get => _salary;}
        private const int _salary = 1;

        public int Morale { get => _morale; set => _morale = value; }
        private int _morale;

        public List<ICloth> AllCloth => new List<ICloth>()
        {
            new Torso(0), new Torso(11), new Torso(28),
            new ArmUpper(0), new ArmUpper(3), new ArmUpper(11), new ArmUpper(16),
            new ArmLower(0), new ArmLower(9), new ArmLower(13),
            new Hand(0), new Hand(7), new Hand(8), new Hand(10), new Hand(15), new Hand(16), new Hand(17),
            new Hips(2), new Hips(10),
            new Leg(0), new Leg(3), new Leg(11), new Leg(17),
            new HeadCoveringsNoHair(0), new HeadCoveringsNoHair(1), new HeadCoveringsNoHair(5), new HeadCoveringsNoHair(6), new HeadCoveringsNoHair(7), new HeadCoveringsNoHair(10),
        };
    }
}

