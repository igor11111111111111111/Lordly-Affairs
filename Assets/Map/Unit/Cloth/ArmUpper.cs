namespace Map
{
    public struct ArmUpper : ICloth
    {
        public int Id { get => _id; set => _id = value; }
        private int _id;

        public ArmUpper(int id)
        {
            _id = id;
        }
    }
}

