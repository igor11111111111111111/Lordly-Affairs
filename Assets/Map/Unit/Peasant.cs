namespace Map
{
    public struct Peasant : IUnit
    {
        public int Price { get => _price; }
        private const int _price = 10;

        public int Salary { get => _salary;}
        private const int _salary = 1;

        public int Morale { get => _morale; set => _morale = value; }
        private int _morale;
    }
}

