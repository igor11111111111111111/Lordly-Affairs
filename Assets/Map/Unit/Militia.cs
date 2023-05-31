namespace Map
{
    public struct Militia : IUnit
    {
        public int Price { get => _price; }
        private const int _price = 20;

        public int Salary { get => _salary;}
        private const int _salary = 3;

        public int Morale { get => _morale; set => _morale = value; }
        private int _morale;
    }
}

